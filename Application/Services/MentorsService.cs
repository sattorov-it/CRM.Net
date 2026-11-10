using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorsService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository _repository = mentorRepository;

    public async Task<ApiResponse<bool>> AddMentorAsync(Mentors mentor)
    {
        var res = await _repository.AddMentorAsync(mentor);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> UpdateMentorAsync(Mentors mentor)
    {
        var res = await _repository.UpdateMentorAsync(mentor);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> DeleteMentorAsync(int mentorId)
    {
        var res = await _repository.DeleteMentorAsync(mentorId);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<Mentors>> GetMentorAsync(int mentorId)
    {
        var res = await _repository.GetMentorAsync(mentorId);
        return res == null
        ? new ApiResponse<Mentors>(HttpStatusCode.NotFound, "Mentor not found!", null)
        : new ApiResponse<Mentors>(HttpStatusCode.OK, "Mentor with given id.", res);
    }

    public async Task<ApiResponse<List<Mentors>>> GetAllMentorsAsync()
    {
        var res = await _repository.GetMentorsAsync();
        return new ApiResponse<List<Mentors>>(HttpStatusCode.OK, "List of mentors.", res);
    }

    public async Task<ApiResponse<dynamic>> GetMentorWithMostStudentsAsync()
    {
        var res = await _repository.GetMentorWithMostStudentsAsync();
        return res == null
        ? new ApiResponse<dynamic>(HttpStatusCode.NotFound, "No mentors!", null)
        : new ApiResponse<dynamic>(HttpStatusCode.OK, "Mentor with most students.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCoursesAsync()
    {
        var res = await _repository.GetMentorsWithMultipleCoursesAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Mentors with multiple courses.", res);
    }
}