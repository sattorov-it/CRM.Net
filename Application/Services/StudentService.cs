using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private StudentRepository _repository = studentRepository;
    public async Task AddStudentAsync(Student student)
    {
        var result = await _repository.AddStudentAsync(student);
        if (result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var result = await _repository.DeleteStudentAsync(studentId);
        if (result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllStudentsAsync()
    {
        var students = await _repository.GetStudentsAsync();
        foreach (var student in students)
        {
            System.Console.WriteLine(student.StudentId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate);
        }
    }

    public async Task GetStudentAsync(int studentId)
    {
        var student = await _repository.GetStudentAsync(studentId);
        System.Console.WriteLine(student.StudentId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var result = await _repository.UpdateStudentAsync(student);
        if (result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

}