using Domain.Models;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    bool AddGroup(Groups group);
    bool UpdateGroup(Groups group);
    bool DeleteGroup(int groupId);
    Groups GetGroup(int groupId);
    List<Groups> GetGroups();
}