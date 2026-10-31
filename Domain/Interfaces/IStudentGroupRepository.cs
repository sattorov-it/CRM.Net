using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    Task<bool> AddStudentToGroupAsync(StudentGroups studentGroup);
    Task<List<dynamic>> GetStudentsInGroupAsync(int groupId);
    Task<bool> UpdateStatusAsync(int studentGroupId, string status);
    Task<bool> RemoveStudentFromGroupAsync(int studentGroupId);
}