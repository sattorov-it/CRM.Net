using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private AppDbContext _context = appDbContext;

    public bool AddCourse(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into courses(title, description, durationweeks) values(@title, @description, @durationweeks)";
        var result = connection.Execute(query, course);
        return result > 0;
    }

    public bool DeleteCourse(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from courses where courseid=@courseid";
        var result = connection.Execute(query, new { courseId });
        return result > 0;
    }

    public Course GetCourse(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses where courseid=@courseid";
        var result = connection.QuerySingle<Course>(query, new { courseId });
        return result;
    }

    public List<Course> GetCourses()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses";
        var result = connection.Query<Course>(query).ToList();
        return result;
    }

    public bool UpdateCourse(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update courses set title=@title, description=@description, durationweeks=@durationweeks where courseid=@courseid";
        var result = connection.Execute(query, course);
        return result > 0;
    }
}