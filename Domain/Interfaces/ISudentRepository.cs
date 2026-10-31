using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<bool> AddStudentAsync(Students student);
    Task<bool> UpdateStudentAsync(Students student);
    Task<bool> DeleteStudentAsync(int studentId);
    Task<Students> GetStudentAsync(int studentId);
    Task<List<Students>> GetStudentsAsync();

    Task<List<dynamic>> GetStudentsWithGroupsAsync();
    Task<List<Students>> GetStudentsWithoutGroupsAsync();
    Task<List<Students>> GetDroppedOutStudentsAsync();
    Task<List<Students>> GetGraduatedStudentsAsync();
}