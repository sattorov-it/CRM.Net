using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorsRepository(AppDbContext appDbContext) : IMentorsRepository
{
    private AppDbContext _context = appDbContext;

    public bool AddMentor(Mentors mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";
        var result = connection.Execute(query, mentor);
        return result > 0;
    }

    public bool DeleteMentor(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from mentors where mentorid=@mentorid";
        var result = connection.Execute(query, new { mentorId });
        return result > 0;
    }

    public Mentors GetMentor(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors where mentorid=@mentorid";
        var result = connection.QuerySingle<Mentors>(query, new { mentorId });
        return result;
    }

    public List<Mentors> GetMentors()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors";
        var result = connection.Query<Mentors>(query).ToList();
        return result;
    }

    public bool UpdateMentor(Mentors mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";
        var result = connection.Execute(query, mentor);
        return result > 0;
    }
}