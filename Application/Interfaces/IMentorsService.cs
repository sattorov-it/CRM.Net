using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task<ApiResponse<bool>> AddMentorAsync(Mentors mentor);
    Task<ApiResponse<bool>> UpdateMentorAsync(Mentors mentor);
    Task<ApiResponse<bool>> DeleteMentorAsync(int mentorId);
    Task<ApiResponse<Mentors>> GetMentorAsync(int mentorId);
    Task<ApiResponse<List<Mentors>>> GetAllMentorsAsync();

    Task<ApiResponse<dynamic>> GetMentorWithMostStudentsAsync();
    Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCoursesAsync();
}