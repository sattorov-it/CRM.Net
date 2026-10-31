using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StatisticsRepository(AppDbContext appDbContext) : IStatisticsRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<int> GetTotalStudentsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from students";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalGroupsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(distinct groupid) from groups";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalCoursesCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(distinct courseid) from courses";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalMentorsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from mentors";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<List<DateTime>> GetAllStartDatesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select distinct startdate from groups order by startdate";
        var result = (await connection.QueryAsync<DateTime>(query)).ToList();
        return result;
    }
}