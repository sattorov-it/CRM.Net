using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGroupService
{
    Task<ApiResponse<bool>> AddGroupAsync(Groups group);
    Task<ApiResponse<bool>> UpdateGroupAsync(Groups group);
    Task<ApiResponse<bool>> DeleteGroupAsync(int groupId);
    Task<ApiResponse<Groups>> GetGroupAsync(int groupId);
    Task<ApiResponse<List<Groups>>> GetAllGroupsAsync();

    Task<ApiResponse<List<dynamic>>> GetStudentsPerGroupAsync();
    Task<ApiResponse<List<Groups>>> GetEmptyGroupsAsync();
}