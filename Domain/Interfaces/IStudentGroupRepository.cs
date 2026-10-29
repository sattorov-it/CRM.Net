// Domain/Interfaces/IStudentGroupRepository.cs
using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    Task<bool> AddStudentGroupAsync(StudentGroups studentGroup);
    Task<bool> UpdateStudentGroupAsync(StudentGroups studentGroup);
    Task<bool> DeleteStudentGroupAsync(int studentGroupId);
    Task<StudentGroups> GetStudentGroupAsync(int studentGroupId);
    Task<List<StudentGroups>> GetStudentGroupsAsync();

}