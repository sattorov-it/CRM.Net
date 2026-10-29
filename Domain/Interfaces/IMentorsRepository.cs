using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorsRepository
{
    Task<bool> AddMentorAsync(Mentors mentor);
    Task<bool> UpdateMentorAsync(Mentors mentor);
    Task<bool> DeleteMentorAsync(int mentorId);
    Task<Mentors> GetMentorAsync(int mentorId);
    Task<List<Mentors>> GetMentorsAsync();
}