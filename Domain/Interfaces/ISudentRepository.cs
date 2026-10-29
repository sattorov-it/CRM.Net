using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    bool AddStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int studentId);
    Student GetStudent(int studentId);
    List<Student> GetStudents();
}