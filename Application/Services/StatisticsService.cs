using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;

namespace Application.Services;

public class StatisticsService(IStatisticsRepository statisticsRepository) : IStatisticsService
{
    private IStatisticsRepository _repository = statisticsRepository;

    public async Task<ApiResponse<int>> GetTotalStudentsCountAsync()
    {
        var res = await _repository.GetTotalStudentsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total students count.", res);
    }

    public async Task<ApiResponse<int>> GetTotalGroupsCountAsync()
    {
        var res = await _repository.GetTotalGroupsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total groups count.", res);
    }

    public async Task<ApiResponse<int>> GetTotalCoursesCountAsync()
    {
        var res = await _repository.GetTotalCoursesCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total courses count.", res);
    }

    public async Task<ApiResponse<int>> GetTotalMentorsCountAsync()
    {
        var res = await _repository.GetTotalMentorsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total mentors count.", res);
    }

    public async Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync()
    {
        var res = await _repository.GetAllStartDatesAsync();
        return new ApiResponse<List<DateTime>>(HttpStatusCode.OK, "All start dates.", res);
    }
}