using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<bool> AddStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int studentId);
    Task<Student> GetStudentAsync(int studentId);
    Task<List<Student>> GetStudentsAsync();
}