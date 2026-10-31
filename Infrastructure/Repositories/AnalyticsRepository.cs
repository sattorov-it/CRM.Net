using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AnalyticsRepository(AppDbContext appDbContext) : IAnalyticsRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<decimal> GetCompletionRateAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select coalesce(round(100.0 * count(*) filter (where status='Завершил') / nullif(count(*), 0), 2), 0) from studentgroups";
        return await connection.ExecuteScalarAsync<decimal>(query);
    }
}