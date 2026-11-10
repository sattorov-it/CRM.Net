using Application.Responses;

namespace Application.Interfaces;

public interface IAnalyticsService
{
    Task<ApiResponse<decimal>> GetCompletionRateAsync();
}