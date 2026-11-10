using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupsService(IGroupRepository groupRepository) : IGroupService
{
    private IGroupRepository _repository = groupRepository;

    public async Task<ApiResponse<bool>> AddGroupAsync(Groups group)
    {
        var res = await _repository.AddGroupAsync(group);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> UpdateGroupAsync(Groups group)
    {
        var res = await _repository.UpdateGroupAsync(group);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> DeleteGroupAsync(int groupId)
    {
        var res = await _repository.DeleteGroupAsync(groupId);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<Groups>> GetGroupAsync(int groupId)
    {
        var res = await _repository.GetGroupAsync(groupId);
        return res == null
        ? new ApiResponse<Groups>(HttpStatusCode.NotFound, "Group not found!", null)
        : new ApiResponse<Groups>(HttpStatusCode.OK, "Group with given id.", res);
    }

    public async Task<ApiResponse<List<Groups>>> GetAllGroupsAsync()
    {
        var res = await _repository.GetGroupsAsync();
        return new ApiResponse<List<Groups>>(HttpStatusCode.OK, "List of groups.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetStudentsPerGroupAsync()
    {
        var res = await _repository.GetStudentsPerGroupAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Students per group.", res);
    }

    public async Task<ApiResponse<List<Groups>>> GetEmptyGroupsAsync()
    {
        var res = await _repository.GetEmptyGroupsAsync();
        return new ApiResponse<List<Groups>>(HttpStatusCode.OK, "Empty groups.", res);
    }
}