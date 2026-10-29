using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private StudentRepository _repository = studentRepository;
    public void AddStudent(Student student)
    {
        var result = _repository.AddStudent(student);
        if (result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public void DeleteStudent(int studentId)
    {
        var result = _repository.DeleteStudent(studentId);
        if (result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public void GetAllStudents()
    {
        var students = _repository.GetStudents();
        foreach (var student in students)
        {
            System.Console.WriteLine(student.StudentId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate);
        }
    }

    public void GetStudent(int studentId)
    {
        var student = _repository.GetStudent(studentId);
        System.Console.WriteLine(student.StudentId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate);
    }

    public void UpdateStudent(Student student)
    {
        var result = _repository.UpdateStudent(student);
        if (result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

}