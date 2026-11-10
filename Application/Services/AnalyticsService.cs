using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;

namespace Application.Services;

public class AnalyticsService(IAnalyticsRepository analyticsRepository) : IAnalyticsService
{
    private IAnalyticsRepository _repository = analyticsRepository;

    public async Task<ApiResponse<decimal>> GetCompletionRateAsync()
    {
        var res = await _repository.GetCompletionRateAsync();
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Completion rate.", res);
    }
}