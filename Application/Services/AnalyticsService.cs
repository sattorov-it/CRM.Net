using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services;

public class AnalyticsService(IAnalyticsRepository analyticsRepository) : IAnalyticsService
{
    private IAnalyticsRepository _repository = analyticsRepository;

    public async Task GetCompletionRateAsync()
    {
        var rate = await _repository.GetCompletionRateAsync();
        Console.WriteLine("Completion rate: " + rate + "%");
    }
}