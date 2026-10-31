using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private IGroupRepository _repository = groupRepository;

    public async Task AddGroupAsync(Groups group)
    {
        var result = await _repository.AddGroupAsync(group);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task UpdateGroupAsync(Groups group)
    {
        var result = await _repository.UpdateGroupAsync(group);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var result = await _repository.DeleteGroupAsync(groupId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Cannot delete: group not found or has students!");
    }

    public async Task GetGroupAsync(int groupId)
    {
        var group = await _repository.GetGroupAsync(groupId);
        if (group == null)
        {
            Console.WriteLine("Group not found!");
            return;
        }
        Console.WriteLine(group.GroupId + " " + group.GroupName + " course:" + group.CourseId + " mentor:" + group.MentorId + " " + group.StartDate.ToShortDateString() + " - " + group.EndDate.ToShortDateString());
    }

    public async Task GetAllGroupsAsync()
    {
        var groups = await _repository.GetGroupsAsync();
        foreach (var group in groups)
        {
            Console.WriteLine(group.GroupId + " " + group.GroupName + " course:" + group.CourseId + " mentor:" + group.MentorId + " " + group.StartDate.ToShortDateString() + " - " + group.EndDate.ToShortDateString());
        }
    }

    public async Task GetStudentsPerGroupAsync()
    {
        var list = await _repository.GetStudentsPerGroupAsync();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.groupname}: {item.studentscount}");
        }
    }

    public async Task GetEmptyGroupsAsync()
    {
        var groups = await _repository.GetEmptyGroupsAsync();
        if (groups.Count == 0) Console.WriteLine("No empty groups!");
        foreach (var group in groups)
        {
            Console.WriteLine(group.GroupId + " " + group.GroupName);
        }
    }
}