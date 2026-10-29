using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddGroupAsync(Groups group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into groups(groupname, courseid, mentorid, startdate, enddate) values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        var result = await connection.ExecuteAsync(query, group);
        return result > 0;
    }

    public async Task<bool> DeleteGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where groupid=@groupid";
        var result = await connection.ExecuteAsync(query, new { groupId });
        return result > 0;
    }

    public async Task<Groups> GetGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where groupid=@groupid";
        var result = await connection.QuerySingleAsync<Groups>(query, new { groupId });
        return result;
    }

    public async Task<List<Groups>> GetGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups";
        var result = await connection.QueryAsync<Groups>(query);
        return result.ToList();
    }

    public async Task<bool> UpdateGroupAsync(Groups group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update groups set groupname=@groupname, courseid=@courseid, mentorid=@mentorid, startdate=@startdate, enddate=@enddate where groupid=@groupid";
        var result = await connection.ExecuteAsync(query, group);
        return result > 0;
    }
}