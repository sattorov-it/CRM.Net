using Domain.Models;

namespace Application.Interfaces;

public interface IGroupService
{
    Task AddGroupAsync(Groups group);
    Task UpdateGroupAsync(Groups group);
    Task DeleteGroupAsync(int groupId);
    Task GetGroupAsync(int groupId);
    Task GetAllGroupsAsync();

    Task GetStudentsPerGroupAsync();
    Task GetEmptyGroupsAsync();
}