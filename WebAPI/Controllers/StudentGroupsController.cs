using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupsController(IStudentGroupService studentGroupService) : ControllerBase
{
    private IStudentGroupService service = studentGroupService;

    [HttpGet("by-group/{groupId:int}")]
    public async Task<ApiResponse<List<dynamic>>> GetStudentsInGroup(int groupId)
    {
        return await service.GetStudentsInGroupAsync(groupId);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentToGroup(StudentGroups studentGroup)
    {
        return await service.AddStudentToGroupAsync(studentGroup);
    }

    [HttpPut("status")]
    public async Task<ApiResponse<bool>> UpdateStatus(int studentGroupId, string status)
    {
        return await service.UpdateStatusAsync(studentGroupId, status);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> RemoveStudentFromGroup(int studentGroupId)
    {
        return await service.RemoveStudentFromGroupAsync(studentGroupId);
    }
}