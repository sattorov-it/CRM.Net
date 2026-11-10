using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorsController(IMentorService mentorService) : ControllerBase
{
    private IMentorService service = mentorService;

    [HttpGet]
    public async Task<ApiResponse<List<Mentors>>> GetMentors()
    {
        return await service.GetAllMentorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Mentors>> GetMentor(int id)
    {
        return await service.GetMentorAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(Mentors mentor)
    {
        return await service.AddMentorAsync(mentor);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMentor(Mentors mentor)
    {
        return await service.UpdateMentorAsync(mentor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        return await service.DeleteMentorAsync(id);
    }

    [HttpGet("most-students")]
    public async Task<ApiResponse<dynamic>> GetMentorWithMostStudents()
    {
        return await service.GetMentorWithMostStudentsAsync();
    }

    [HttpGet("multiple-courses")]
    public async Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCourses()
    {
        return await service.GetMentorsWithMultipleCoursesAsync();
    }
}