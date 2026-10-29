using Domain.Models;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    Task <bool> AddGroupAsync(Groups group);
    Task <bool> UpdateGroupAsync(Groups group);
    Task <bool> DeleteGroupAsync(int groupId);
    Task <Groups> GetGroupAsync(int groupId);
    Task <List<Groups>> GetGroupsAsync();
}