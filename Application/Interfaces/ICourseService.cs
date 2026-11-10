using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task<ApiResponse<bool>> AddCourseAsync(Course course);
    Task<ApiResponse<bool>> UpdateCourseAsync(Course course);
    Task<ApiResponse<bool>> DeleteCourseAsync(int courseId);
    Task<ApiResponse<Course>> GetCourseAsync(int courseId);
    Task<ApiResponse<List<Course>>> GetAllCoursesAsync();

    Task<ApiResponse<List<dynamic>>> GetStudentsPerCourseAsync();
    Task<ApiResponse<dynamic>> GetMostPopularCourseAsync();
    Task<ApiResponse<List<dynamic>>> GetLeastPopularCoursesAsync();
    Task<ApiResponse<List<dynamic>>> GetTopThreeCoursesAsync();
}