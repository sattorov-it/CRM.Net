using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    private AppDbContext _context = appDbContext;
    public bool AddStudent(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into students(fullname, email, phone, enrollmentdate) values(@fullname, @email, @phone, @enrollmentdate)";
        var result = connection.Execute(query, student);
        return result > 0;
    }

    public bool DeleteStudent(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from students where studentid=@studentid";
        var result = connection.Execute(query, new { studentId });
        return result > 0;
    }

    public Student GetStudent(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students where studentid=@studentid";
        var result = connection.QuerySingle<Student>(query, new { studentId });
        return result;
    }

    public List<Student> GetStudents()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students";
        var result = connection.Query<Student>(query).ToList();
        return result;
    }

    public bool UpdateStudent(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update students set fullname=@fullname, email=@email, phone=@phone, enrollmentdate=@enrollmentdate where studentid=@studentid";
        var result = connection.Execute(query, student);
        return result > 0;
    }

}

