using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorsRepository
{
    bool AddMentor(Mentors mentor);
    bool UpdateMentor(Mentors mentor);
    bool DeleteMentor(int mentorId);
    Mentors GetMentor(int mentorId);
    List<Mentors> GetMentors();
}