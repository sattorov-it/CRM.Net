using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext appDbContext) : IStudentGroupRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddStudentToGroupAsync(StudentGroups studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into studentgroups(studentid, groupid, status) values(@studentid, @groupid, @status)";
        var result = await connection.ExecuteAsync(query, studentGroup);
        return result > 0;
    }

    public async Task<List<dynamic>> GetStudentsInGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select sg.studentgroupid, s.studentid, s.fullname, sg.status from studentgroups sg join students s on s.studentid=sg.studentid where sg.groupid=@groupid";
        var result = (await connection.QueryAsync(query, new { groupId })).ToList();
        return result;
    }

    public async Task<bool> UpdateStatusAsync(int studentGroupId, string status)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update studentgroups set status=@status where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, new { studentGroupId, status });
        return result > 0;
    }

    public async Task<bool> RemoveStudentFromGroupAsync(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from studentgroups where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, new { studentGroupId });
        return result > 0;
    }
}