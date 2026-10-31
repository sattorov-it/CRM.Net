using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services;

public class StatisticsService(IStatisticsRepository statisticsRepository) : IStatisticsService
{
    private IStatisticsRepository _repository = statisticsRepository;

    public async Task GetTotalStudentsCountAsync()
    {
        var count = await _repository.GetTotalStudentsCountAsync();
        Console.WriteLine("Total students: " + count);
    }

    public async Task GetTotalGroupsCountAsync()
    {
        var count = await _repository.GetTotalGroupsCountAsync();
        Console.WriteLine("Total groups: " + count);
    }

    public async Task GetTotalCoursesCountAsync()
    {
        var count = await _repository.GetTotalCoursesCountAsync();
        Console.WriteLine("Total courses: " + count);
    }

    public async Task GetTotalMentorsCountAsync()
    {
        var count = await _repository.GetTotalMentorsCountAsync();
        Console.WriteLine("Total mentors: " + count);
    }

    public async Task GetAllStartDatesAsync()
    {
        var dates = await _repository.GetAllStartDatesAsync();
        foreach (var date in dates)
        {
            Console.WriteLine(date.ToShortDateString());
        }
    }
}