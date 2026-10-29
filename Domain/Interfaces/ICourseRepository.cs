using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    bool AddCourse(Course course);
    bool UpdateCourse(Course course);
    bool DeleteCourse(int courseId);
    Course GetCourse(int courseId);
    List<Course> GetCourses();
}