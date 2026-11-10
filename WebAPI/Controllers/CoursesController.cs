using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    private ICourseService service = courseService;

    [HttpGet]
    public async Task<ApiResponse<List<Course>>> GetCourses()
    {
        return await service.GetAllCoursesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Course>> GetCourse(int id)
    {
        return await service.GetCourseAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(Course course)
    {
        return await service.AddCourseAsync(course);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCourse(Course course)
    {
        return await service.UpdateCourseAsync(course);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourse(int id)
    {
        return await service.DeleteCourseAsync(id);
    }

    [HttpGet("students-per-course")]
    public async Task<ApiResponse<List<dynamic>>> GetStudentsPerCourse()
    {
        return await service.GetStudentsPerCourseAsync();
    }

    [HttpGet("most-popular")]
    public async Task<ApiResponse<dynamic>> GetMostPopularCourse()
    {
        return await service.GetMostPopularCourseAsync();
    }

    [HttpGet("least-popular")]
    public async Task<ApiResponse<List<dynamic>>> GetLeastPopularCourses()
    {
        return await service.GetLeastPopularCoursesAsync();
    }

    [HttpGet("top-three")]
    public async Task<ApiResponse<List<dynamic>>> GetTopThreeCourses()
    {
        return await service.GetTopThreeCoursesAsync();
    }
}