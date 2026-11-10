using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(IStatisticsService statisticsService) : ControllerBase
{
    private IStatisticsService service = statisticsService;

    [HttpGet("students-count")]
    public async Task<ApiResponse<int>> GetTotalStudentsCount()
    {
        return await service.GetTotalStudentsCountAsync();
    }

    [HttpGet("groups-count")]
    public async Task<ApiResponse<int>> GetTotalGroupsCount()
    {
        return await service.GetTotalGroupsCountAsync();
    }

    [HttpGet("courses-count")]
    public async Task<ApiResponse<int>> GetTotalCoursesCount()
    {
        return await service.GetTotalCoursesCountAsync();
    }

    [HttpGet("mentors-count")]
    public async Task<ApiResponse<int>> GetTotalMentorsCount()
    {
        return await service.GetTotalMentorsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<List<DateTime>>> GetAllStartDates()
    {
        return await service.GetAllStartDatesAsync();
    }
}