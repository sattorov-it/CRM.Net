using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddStudentAsync(Students student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into students(fullname, email, phone, enrollmentdate) values(@fullname, @email, @phone, @enrollmentdate)";
        var result = await connection.ExecuteAsync(query, student);
        return result > 0;
    }

    public async Task<bool> UpdateStudentAsync(Students student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update students set fullname=@fullname, email=@email, phone=@phone, enrollmentdate=@enrollmentdate where studentid=@studentid";
        var result = await connection.ExecuteAsync(query, student);
        return result > 0;
    }

    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from students where studentid=@studentid and not exists (select 1 from studentgroups where studentid=@studentid)";
        var result = await connection.ExecuteAsync(query, new { studentId });
        return result > 0;
    }

    public async Task<Students> GetStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students where studentid=@studentid";
        var result = await connection.QuerySingleOrDefaultAsync<Students>(query, new { studentId });
        return result;
    }

    public async Task<List<Students>> GetStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students order by studentid";
        var result = (await connection.QueryAsync<Students>(query)).ToList();
        return result;
    }

    public async Task<List<dynamic>> GetStudentsWithGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select s.studentid, s.fullname, g.groupname from students s join studentgroups sg on sg.studentid=s.studentid join groups g on g.groupid=sg.groupid order by s.studentid";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<List<Students>> GetStudentsWithoutGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students s where not exists (select 1 from studentgroups sg where sg.studentid=s.studentid)";
        var result = (await connection.QueryAsync<Students>(query)).ToList();
        return result;
    }

    public async Task<List<Students>> GetDroppedOutStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select distinct * from students s join studentgroups sg on sg.studentid=s.studentid where sg.status='Отчислен'";
        var result = (await connection.QueryAsync<Students>(query)).ToList();
        return result;
    }

    public async Task<List<Students>> GetGraduatedStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select distinct * from students s join studentgroups sg on sg.studentid=s.studentid join groups g on g.groupid=sg.groupid where g.enddate < current_date";
        var result = (await connection.QueryAsync<Students>(query)).ToList();
        return result;
    }
}