using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository _repository = mentorRepository;

    public async Task AddMentorAsync(Mentors mentor)
    {
        var result = await _repository.AddMentorAsync(mentor);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task UpdateMentorAsync(Mentors mentor)
    {
        var result = await _repository.UpdateMentorAsync(mentor);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var result = await _repository.DeleteMentorAsync(mentorId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Cannot delete: mentor not found or has a group!");
    }

    public async Task GetMentorAsync(int mentorId)
    {
        var mentor = await _repository.GetMentorAsync(mentorId);
        if (mentor == null)
        {
            Console.WriteLine("Mentor not found!");
            return;
        }
        Console.WriteLine(mentor.MentorId + " " + mentor.FullName + " " + mentor.Email + " " + mentor.Phone + " " + mentor.Specialization);
    }

    public async Task GetAllMentorsAsync()
    {
        var mentors = await _repository.GetMentorsAsync();
        foreach (var mentor in mentors)
        {
            Console.WriteLine(mentor.MentorId + " " + mentor.FullName + " " + mentor.Email + " " + mentor.Phone + " " + mentor.Specialization);
        }
    }

    public async Task GetMentorWithMostStudentsAsync()
    {
        var item = await _repository.GetMentorWithMostStudentsAsync();
        if (item == null)
        {
            Console.WriteLine("No data!");
            return;
        }
        Console.WriteLine($"{item.fullname}: {item.studentscount} students");
    }

    public async Task GetMentorsWithMultipleCoursesAsync()
    {
        var list = await _repository.GetMentorsWithMultipleCoursesAsync();
        if (list.Count == 0) Console.WriteLine("No such mentors!");
        foreach (var item in list)
        {
            Console.WriteLine($"{item.fullname}: {item.coursescount} courses");
        }
    }
}