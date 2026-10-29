using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext appDbContext) : IStudentGroupRepository
{
    private AppDbContext _context = appDbContext;

    public bool AddStudentGroup(StudentGroups studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into studentgroups(studentid, groupid, status) values(@studentid, @groupid, @status)";
        var result = connection.Execute(query, studentGroup);
        return result > 0;
    }

    public bool DeleteStudentGroup(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from studentgroups where studentgroupid=@studentgroupid";
        var result = connection.Execute(query, new { studentGroupId });
        return result > 0;
    }

    public StudentGroups GetStudentGroup(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from studentgroups where studentgroupid=@studentgroupid";
        var result = connection.QuerySingle<StudentGroups>(query, new { studentGroupId });
        return result;
    }

    public List<StudentGroups> GetStudentGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from studentgroups";
        var result = connection.Query<StudentGroups>(query).ToList();
        return result;
    }

    public bool UpdateStudentGroup(StudentGroups studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update studentgroups set studentid=@studentid, groupid=@groupid, status=@status where studentgroupid=@studentgroupid";
        var result = connection.Execute(query, studentGroup);
        return result > 0;
    }

}