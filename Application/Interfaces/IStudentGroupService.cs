using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task<ApiResponse<bool>> AddStudentToGroupAsync(StudentGroups studentGroup);
    Task<ApiResponse<List<dynamic>>> GetStudentsInGroupAsync(int groupId);
    Task<ApiResponse<bool>> UpdateStatusAsync(int studentGroupId, string status);
    Task<ApiResponse<bool>> RemoveStudentFromGroupAsync(int studentGroupId);
}