using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController(IGroupService groupService) : ControllerBase
{
    private IGroupService service = groupService;

    [HttpGet]
    public async Task<ApiResponse<List<Groups>>> GetGroups()
    {
        return await service.GetAllGroupsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Groups>> GetGroup(int id)
    {
        return await service.GetGroupAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(Groups group)
    {
        return await service.AddGroupAsync(group);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGroup(Groups group)
    {
        return await service.UpdateGroupAsync(group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        return await service.DeleteGroupAsync(id);
    }

    [HttpGet("students-per-group")]
    public async Task<ApiResponse<List<dynamic>>> GetStudentsPerGroup()
    {
        return await service.GetStudentsPerGroupAsync();
    }

    [HttpGet("empty")]
    public async Task<ApiResponse<List<Groups>>> GetEmptyGroups()
    {
        return await service.GetEmptyGroupsAsync();
    }
}