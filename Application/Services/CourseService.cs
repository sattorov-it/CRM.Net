using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private ICourseRepository _repository = courseRepository;

    public async Task AddCourseAsync(Course course)
    {
        var result = await _repository.AddCourseAsync(course);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var result = await _repository.UpdateCourseAsync(course);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var result = await _repository.DeleteCourseAsync(courseId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Cannot delete: course not found or has groups!");
    }

    public async Task GetCourseAsync(int courseId)
    {
        var course = await _repository.GetCourseAsync(courseId);
        if (course == null)
        {
            Console.WriteLine("Course not found!");
            return;
        }
        Console.WriteLine(course.CourseId + " " + course.Title + " " + course.Description + " " + course.DurationWeeks + " weeks");
    }

    public async Task GetAllCoursesAsync()
    {
        var courses = await _repository.GetCoursesAsync();
        foreach (var course in courses)
        {
            Console.WriteLine(course.CourseId + " " + course.Title + " " + course.Description + " " + course.DurationWeeks + " weeks");
        }
    }

    public async Task GetStudentsPerCourseAsync()
    {
        var list = await _repository.GetStudentsPerCourseAsync();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.title}: {item.studentscount}");
        }
    }

    public async Task GetMostPopularCourseAsync()
    {
        var item = await _repository.GetMostPopularCourseAsync();
        if (item == null)
        {
            Console.WriteLine("No courses!");
            return;
        }
        Console.WriteLine($"{item.title}: {item.studentscount}");
    }

    public async Task GetLeastPopularCoursesAsync()
    {
        var list = await _repository.GetLeastPopularCoursesAsync();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.title}: {item.studentscount}");
        }
    }

    public async Task GetTopThreeCoursesAsync()
    {
        var list = await _repository.GetTopThreeCoursesAsync();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.title}: {item.studentscount}");
        }
    }
}