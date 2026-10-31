using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupService(IStudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private IStudentGroupRepository _repository = studentGroupRepository;

    public async Task AddStudentToGroupAsync(StudentGroups studentGroup)
    {
        var result = await _repository.AddStudentToGroupAsync(studentGroup);
        if (result) Console.WriteLine("Student added to group!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task GetStudentsInGroupAsync(int groupId)
    {
        var list = await _repository.GetStudentsInGroupAsync(groupId);
        if (list.Count == 0) Console.WriteLine("No students in this group!");
        foreach (var item in list)
        {
            Console.WriteLine($"{item.studentgroupid} {item.fullname} - {item.status}");
        }
    }

    public async Task UpdateStatusAsync(int studentGroupId, string status)
    {
        var result = await _repository.UpdateStatusAsync(studentGroupId, status);
        if (result) Console.WriteLine("Status updated!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task RemoveStudentFromGroupAsync(int studentGroupId)
    {
        var result = await _repository.RemoveStudentFromGroupAsync(studentGroupId);
        if (result) Console.WriteLine("Student removed from group!");
        else Console.WriteLine("Something went wrong!");
    }
}