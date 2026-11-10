using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ApiResponse<bool>> AddStudentAsync(Students student);
    Task<ApiResponse<bool>> UpdateStudentAsync(Students student);
    Task<ApiResponse<bool>> DeleteStudentAsync(int studentId);
    Task<ApiResponse<Students>> GetStudentAsync(int studentId);
    Task<ApiResponse<List<Students>>> GetAllStudentsAsync();

    Task<ApiResponse<List<dynamic>>> GetStudentsWithGroupsAsync();
    Task<ApiResponse<List<Students>>> GetStudentsWithoutGroupsAsync();
    Task<ApiResponse<List<Students>>> GetDroppedOutStudentsAsync();
    Task<ApiResponse<List<Students>>> GetGraduatedStudentsAsync();
}