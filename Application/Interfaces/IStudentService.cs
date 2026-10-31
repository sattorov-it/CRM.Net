using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task AddStudentAsync(Students student);
    Task UpdateStudentAsync(Students student);
    Task DeleteStudentAsync(int studentId);
    Task GetStudentAsync(int studentId);
    Task GetAllStudentsAsync();

    Task GetStudentsWithGroupsAsync();
    Task GetStudentsWithoutGroupsAsync();
    Task GetDroppedOutStudentsAsync();
    Task GetGraduatedStudentsAsync();
}