using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task AddStudentToGroupAsync(StudentGroups studentGroup);
    Task GetStudentsInGroupAsync(int groupId);
    Task UpdateStatusAsync(int studentGroupId, string status);
    Task RemoveStudentFromGroupAsync(int studentGroupId);
}