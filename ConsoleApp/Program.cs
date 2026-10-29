using System.Formats.Tar;
using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var appDbContext = new AppDbContext();
var studentRepository = new StudentRepository(appDbContext);
var studentService = new StudentService(studentRepository);

while (true)
{
    System.Console.WriteLine("==================================");
    System.Console.WriteLine(@"1 - Show all students.
2 - Show student.
3 - Add new student.
4 - Update student.
5 - Delete student.
0 - Exit.");
    var option = Console.ReadLine();
    System.Console.WriteLine("==================================");

    switch (option)
    {
        case "1":
            studentService.GetAllStudents();
            break;
        case "2":
            System.Console.Write("Enter id: ");
            var student_id = Convert.ToInt32(Console.ReadLine());
            studentService.GetStudent(student_id);
            break;
        case "3":
            System.Console.Write("Enter fullname: ");
            var fullname = Console.ReadLine()!;
            System.Console.Write("Enter email: ");
            var email = Console.ReadLine()!;
            System.Console.Write("Enter phone: ");
            var phone = Console.ReadLine()!;
            System.Console.Write("Enter enrollment date: ");
            var enrollmentDate = Convert.ToDateTime(Console.ReadLine());
            var student = new Student()
            {
                Fullname = fullname,
                Email = email,
                Phone = phone,
                EnrollmentDate = DateOnly.FromDateTime(enrollmentDate)
            };
            studentService.AddStudent(student);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var uStudentId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter fullname: ");
            var uFullname = Console.ReadLine()!;
            System.Console.Write("Enter email: ");
            var uEmail = Console.ReadLine()!;
            System.Console.Write("Enter phone: ");
            var uPhone = Console.ReadLine()!;
            System.Console.Write("Enter enrollment date: ");
            var uEnrollmentDate = Convert.ToDateTime(Console.ReadLine());
            var uStudent = new Student()
            {
                StudentId = uStudentId,
                Fullname = uFullname,
                Email = uEmail,
                Phone = uPhone,
                EnrollmentDate = DateOnly.FromDateTime(uEnrollmentDate)
            };
            studentService.UpdateStudent(uStudent);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var dStudentId = Convert.ToInt32(Console.ReadLine());
            studentService.DeleteStudent(dStudentId);
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}