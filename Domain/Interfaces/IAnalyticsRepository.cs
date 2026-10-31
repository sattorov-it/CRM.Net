namespace Domain.Interfaces;

public interface IAnalyticsRepository
{
    Task<decimal> GetCompletionRateAsync();
}