using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IGroupsService
{
    bool DeleteGroup(int id);
    bool UpdateGroup(Groups user);
    bool InsertGroup(Groups user);
    List<Groups> Groups();
    Groups GetGroupById(int id);
}