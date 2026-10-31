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

    public async Task<bool> UpdateGroupAsync(Groups group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update groups set groupname=@groupname, courseid=@courseid, mentorid=@mentorid, startdate=@startdate, enddate=@enddate where groupid=@groupid";
        var result = await connection.ExecuteAsync(query, group);
        return result > 0;
    }

    public async Task<bool> DeleteGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where groupid=@groupid and not exists (select 1 from studentgroups where groupid=@groupid)";
        var result = await connection.ExecuteAsync(query, new { groupId });
        return result > 0;
    }

    public async Task<Groups?> GetGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where groupid=@groupid";
        var result = await connection.QuerySingleOrDefaultAsync<Groups>(query, new { groupId });
        return result;
    }

    public async Task<List<Groups>> GetGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups order by groupid";
        var result = (await connection.QueryAsync<Groups>(query)).ToList();
        return result;
    }

    public async Task<List<dynamic>> GetStudentsPerGroupAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select g.groupname, count(sg.studentid) as studentscount
                      from groups g
                      left join studentgroups sg on sg.groupid=g.groupid
                      group by g.groupid, g.groupname
                      order by g.groupid";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<List<Groups>> GetEmptyGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups g where not exists (select 1 from studentgroups sg where sg.groupid=g.groupid)";
        var result = (await connection.QueryAsync<Groups>(query)).ToList();
        return result;
    }
}