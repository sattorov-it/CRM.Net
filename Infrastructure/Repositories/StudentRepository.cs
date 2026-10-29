using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddStudentAsync(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into students(fullname, email, phone, enrollmentdate) values(@fullname, @email, @phone, @enrollmentdate)";
        var result = await connection.ExecuteAsync(query, student);
        return result > 0;
    }

    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from students where studentid=@studentid";
        var result =await connection.ExecuteAsync(query, new { studentId });
        return result > 0;
    }

    public async Task<Student> GetStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students where studentid=@studentid";
        var result = await connection.QuerySingleAsync<Student>(query, new { studentId });
        return result;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students";
        var result = await connection.QueryAsync<Student>(query);
        return result.ToList();
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update students set fullname=@fullname, email=@email, phone=@phone, enrollmentdate=@enrollmentdate where studentid=@studentid";
        var result = await connection.ExecuteAsync(query, student);
        return result > 0;
    }

}

