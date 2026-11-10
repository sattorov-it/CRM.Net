using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupService(IStudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private IStudentGroupRepository _repository = studentGroupRepository;

    public async Task<ApiResponse<bool>> AddStudentToGroupAsync(StudentGroups studentGroup)
    {
        var res = await _repository.AddStudentToGroupAsync(studentGroup);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetStudentsInGroupAsync(int groupId)
    {
        var res = await _repository.GetStudentsInGroupAsync(groupId);
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Students in group.", res);
    }

    public async Task<ApiResponse<bool>> UpdateStatusAsync(int studentGroupId, string status)
    {
        var res = await _repository.UpdateStatusAsync(studentGroupId, status);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> RemoveStudentFromGroupAsync(int studentGroupId)
    {
        var res = await _repository.RemoveStudentFromGroupAsync(studentGroupId);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Removed successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }
}