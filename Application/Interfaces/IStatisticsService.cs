using Application.Responses;

namespace Application.Interfaces;

public interface IStatisticsService
{
    Task<ApiResponse<int>> GetTotalStudentsCountAsync();
    Task<ApiResponse<int>> GetTotalGroupsCountAsync();
    Task<ApiResponse<int>> GetTotalCoursesCountAsync();
    Task<ApiResponse<int>> GetTotalMentorsCountAsync();
    Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync();
}