using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    private AppDbContext _context = appDbContext;

    public bool AddGroup(Groups group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into groups(groupname, courseid, mentorid, startdate, enddate) values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        var result = connection.Execute(query, group);
        return result > 0;
    }

    public bool DeleteGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where groupid=@groupid";
        var result = connection.Execute(query, new { groupId });
        return result > 0;
    }

    public Groups GetGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where groupid=@groupid";
        var result = connection.QuerySingle<Groups>(query, new { groupId });
        return result;
    }

    public List<Groups> GetGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups";
        var result = connection.Query<Groups>(query).ToList();
        return result;
    }

    public bool UpdateGroup(Groups group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update groups set groupname=@groupname, courseid=@courseid, mentorid=@mentorid, startdate=@startdate, enddate=@enddate where groupid=@groupid";
        var result = connection.Execute(query, group);
        return result > 0;
    }
}