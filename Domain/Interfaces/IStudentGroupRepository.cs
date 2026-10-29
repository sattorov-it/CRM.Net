// Domain/Interfaces/IStudentGroupRepository.cs
using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    bool AddStudentGroup(StudentGroups studentGroup);
    bool UpdateStudentGroup(StudentGroups studentGroup);
    bool DeleteStudentGroup(int studentGroupId);
    StudentGroups GetStudentGroup(int studentGroupId);
    List<StudentGroups> GetStudentGroups();

}