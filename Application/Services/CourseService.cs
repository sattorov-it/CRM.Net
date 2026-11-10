using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private ICourseRepository _repository = courseRepository;

    public async Task<ApiResponse<bool>> AddCourseAsync(Course course)
    {
        var res = await _repository.AddCourseAsync(course);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> UpdateCourseAsync(Course course)
    {
        var res = await _repository.UpdateCourseAsync(course);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> DeleteCourseAsync(int courseId)
    {
        var res = await _repository.DeleteCourseAsync(courseId);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Cannot delete: course not found or has groups!", res);
    }

    public async Task<ApiResponse<Course>> GetCourseAsync(int courseId)
    {
        var res = await _repository.GetCourseAsync(courseId);
        return res == null
        ? new ApiResponse<Course>(HttpStatusCode.NotFound, "Course not found!", null)
        : new ApiResponse<Course>(HttpStatusCode.OK, "Course with given id.", res);
    }

    public async Task<ApiResponse<List<Course>>> GetAllCoursesAsync()
    {
        var res = await _repository.GetCoursesAsync();
        return new ApiResponse<List<Course>>(HttpStatusCode.OK, "List of courses.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetStudentsPerCourseAsync()
    {
        var res = await _repository.GetStudentsPerCourseAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Students per course.", res);
    }

    public async Task<ApiResponse<dynamic>> GetMostPopularCourseAsync()
    {
        var res = await _repository.GetMostPopularCourseAsync();
        return res == null
        ? new ApiResponse<dynamic>(HttpStatusCode.NotFound, "No courses!", null)
        : new ApiResponse<dynamic>(HttpStatusCode.OK, "Most popular course.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetLeastPopularCoursesAsync()
    {
        var res = await _repository.GetLeastPopularCoursesAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Least popular courses.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetTopThreeCoursesAsync()
    {
        var res = await _repository.GetTopThreeCoursesAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Top three courses.", res);
    }
}