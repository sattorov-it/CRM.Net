using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private IStudentRepository _repository = studentRepository;

    public async Task AddStudentAsync(Students student)
    {
        var result = await _repository.AddStudentAsync(student);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task UpdateStudentAsync(Students student)
    {
        var result = await _repository.UpdateStudentAsync(student);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var result = await _repository.DeleteStudentAsync(studentId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Cannot delete: student not found or is in a group!");
    }

    public async Task GetStudentAsync(int studentId)
    {
        var student = await _repository.GetStudentAsync(studentId);
        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }
        Console.WriteLine(student.StudentsId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate.ToShortDateString());
    }

    public async Task GetAllStudentsAsync()
    {
        var students = await _repository.GetStudentsAsync();
        foreach (var student in students)
        {
            Console.WriteLine(student.StudentsId + " " + student.Fullname + " " + student.Email + " " + student.Phone + " " + student.EnrollmentDate.ToShortDateString());
        }
    }

    public async Task GetStudentsWithGroupsAsync()
    {
        var list = await _repository.GetStudentsWithGroupsAsync();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.studentid} {item.fullname} - {item.groupname}");
        }
    }

    public async Task GetStudentsWithoutGroupsAsync()
    {
        var students = await _repository.GetStudentsWithoutGroupsAsync();
        foreach (var student in students)
        {
            Console.WriteLine(student.StudentsId + " " + student.Fullname);
        }
    }

    public async Task GetDroppedOutStudentsAsync()
    {
        var students = await _repository.GetDroppedOutStudentsAsync();
        foreach (var student in students)
        {
            Console.WriteLine(student.StudentsId + " " + student.Fullname);
        }
    }

    public async Task GetGraduatedStudentsAsync()
    {
        var students = await _repository.GetGraduatedStudentsAsync();
        foreach (var student in students)
        {
            Console.WriteLine(student.StudentsId + " " + student.Fullname);
        }
    }
}