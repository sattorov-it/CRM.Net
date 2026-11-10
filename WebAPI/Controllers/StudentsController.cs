using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    private IStudentService service = studentService;

    [HttpGet]
    public async Task<ApiResponse<List<Students>>> GetStudents()
    {
        return await service.GetAllStudentsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Students>> GetStudent(int id)
    {
        return await service.GetStudentAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(Students student)
    {
        return await service.AddStudentAsync(student);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudent(Students student)
    {
        return await service.UpdateStudentAsync(student);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        return await service.DeleteStudentAsync(id);
    }

    [HttpGet("with-groups")]
    public async Task<ApiResponse<List<dynamic>>> GetStudentsWithGroups()
    {
        return await service.GetStudentsWithGroupsAsync();
    }

    [HttpGet("without-groups")]
    public async Task<ApiResponse<List<Students>>> GetStudentsWithoutGroups()
    {
        return await service.GetStudentsWithoutGroupsAsync();
    }

    [HttpGet("dropped-out")]
    public async Task<ApiResponse<List<Students>>> GetDroppedOutStudents()
    {
        return await service.GetDroppedOutStudentsAsync();
    }

    [HttpGet("graduated")]
    public async Task<ApiResponse<List<Students>>> GetGraduatedStudents()
    {
        return await service.GetGraduatedStudentsAsync();
    }
}