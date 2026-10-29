using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    Task<bool> AddCourseAsync(Course course);
    Task<bool> UpdateCourseAsync(Course course);
    Task<bool> DeleteCourseAsync(int courseId);
    Task<Course> GetCourseAsync(int courseId);
    Task<List<Course>> GetCoursesAsync();
}