using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task AddMentorAsync(Mentors mentor);
    Task UpdateMentorAsync(Mentors mentor);
    Task DeleteMentorAsync(int mentorId);
    Task GetMentorAsync(int mentorId);
    Task GetAllMentorsAsync();

    Task GetMentorWithMostStudentsAsync();
    Task GetMentorsWithMultipleCoursesAsync();
}