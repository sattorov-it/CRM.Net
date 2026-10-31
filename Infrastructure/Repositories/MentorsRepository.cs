using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddMentorAsync(Mentors mentor)
    {
        using var connection = _context.Connection();
        
        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }

    public async Task<bool> UpdateMentorAsync(Mentors mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }

    public async Task<bool> DeleteMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from mentors where mentorid=@mentorid and not exists (select 1 from groups where mentorid=@mentorid)";
        var result = await connection.ExecuteAsync(query, new { mentorId });
        return result > 0;
    }

    public async Task<Mentors?> GetMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors where mentorid=@mentorid";
        var result = await connection.QuerySingleOrDefaultAsync<Mentors>(query, new { mentorId });
        return result;
    }

    public async Task<List<Mentors>> GetMentorsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors order by mentorid";
        var result = (await connection.QueryAsync<Mentors>(query)).ToList();
        return result;
    }

    public async Task<dynamic?> GetMentorWithMostStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select m.fullname, count(sg.studentid) as studentscount
                      from mentors m
                      join groups g on g.mentorid=m.mentorid
                      join studentgroups sg on sg.groupid=g.groupid
                      group by m.mentorid, m.fullname
                      order by studentscount desc
                      limit 1";
        var result = await connection.QueryFirstOrDefaultAsync(query);
        return result;
    }

    public async Task<List<dynamic>> GetMentorsWithMultipleCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select m.fullname, count(distinct g.courseid) as coursescount
                      from mentors m
                      join groups g on g.mentorid=m.mentorid
                      group by m.mentorid, m.fullname
                      having count(distinct g.courseid) > 1";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }
}