using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddCourseAsync(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into courses(title, description, durationweeks) values(@title, @description, @durationweeks)";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }

    public async Task<bool> UpdateCourseAsync(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update courses set title=@title, description=@description, durationweeks=@durationweeks where courseid=@courseid";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {

        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from courses where courseid=@courseid and not exists (select 1 from groups where courseid=@courseid)";
        var result = await connection.ExecuteAsync(query, new { courseId });
        return result > 0;
    }

    public async Task<Course?> GetCourseAsync(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses where courseid=@courseid";
        var result = await connection.QuerySingleOrDefaultAsync<Course>(query, new { courseId });
        return result;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses order by courseid";
        var result = (await connection.QueryAsync<Course>(query)).ToList();
        return result;
    }

    public async Task<List<dynamic>> GetStudentsPerCourseAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select c.title, count(distinct sg.studentid) as studentscount
                      from courses c
                      left join groups g on g.courseid=c.courseid
                      left join studentgroups sg on sg.groupid=g.groupid
                      group by c.courseid, c.title
                      order by c.courseid";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<dynamic?> GetMostPopularCourseAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select c.title, count(distinct sg.studentid) as studentscount
                      from courses c
                      left join groups g on g.courseid=c.courseid
                      left join studentgroups sg on sg.groupid=g.groupid
                      group by c.courseid, c.title
                      order by studentscount desc, c.title
                      limit 1";
        var result = await connection.QueryFirstOrDefaultAsync(query);
        return result;
    }

    public async Task<List<dynamic>> GetLeastPopularCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select c.title, count(distinct sg.studentid) as studentscount
                      from courses c
                      left join groups g on g.courseid=c.courseid
                      left join studentgroups sg on sg.groupid=g.groupid
                      group by c.courseid, c.title
                      order by studentscount asc, c.title
                      limit 3";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<List<dynamic>> GetTopThreeCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select c.title, count(distinct sg.studentid) as studentscount
                      from courses c
                      left join groups g on g.courseid=c.courseid
                      left join studentgroups sg on sg.groupid=g.groupid
                      group by c.courseid, c.title
                      order by studentscount desc, c.title
                      limit 3";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }
}