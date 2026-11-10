using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private IStudentRepository _repository = studentRepository;

    public async Task<ApiResponse<bool>> AddStudentAsync(Students student)
    {
        var res = await _repository.AddStudentAsync(student);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> UpdateStudentAsync(Students student)
    {
        var res = await _repository.UpdateStudentAsync(student);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<bool>> DeleteStudentAsync(int studentId)
    {
        var res = await _repository.DeleteStudentAsync(studentId);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted successfully!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Something went wrong!", res);
    }

    public async Task<ApiResponse<Students>> GetStudentAsync(int studentId)
    {
        var res = await _repository.GetStudentAsync(studentId);
        return res == null
        ? new ApiResponse<Students>(HttpStatusCode.NotFound, "Student not found!", null)
        : new ApiResponse<Students>(HttpStatusCode.OK, "Student with given id.", res);
    }

    public async Task<ApiResponse<List<Students>>> GetAllStudentsAsync()
    {
        var res = await _repository.GetStudentsAsync();
        return new ApiResponse<List<Students>>(HttpStatusCode.OK, "List of students.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetStudentsWithGroupsAsync()
    {
        var res = await _repository.GetStudentsWithGroupsAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Students with groups.", res);
    }

    public async Task<ApiResponse<List<Students>>> GetStudentsWithoutGroupsAsync()
    {
        var res = await _repository.GetStudentsWithoutGroupsAsync();
        return new ApiResponse<List<Students>>(HttpStatusCode.OK, "Students without groups.", res);
    }

    public async Task<ApiResponse<List<Students>>> GetDroppedOutStudentsAsync()
    {
        var res = await _repository.GetDroppedOutStudentsAsync();
        return new ApiResponse<List<Students>>(HttpStatusCode.OK, "Dropped out students.", res);
    }

    public async Task<ApiResponse<List<Students>>> GetGraduatedStudentsAsync()
    {
        var res = await _repository.GetGraduatedStudentsAsync();
        return new ApiResponse<List<Students>>(HttpStatusCode.OK, "Graduated students.", res);
    }
}