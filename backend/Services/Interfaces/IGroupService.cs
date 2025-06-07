using backend.Models;
using backend.Utilities;

namespace backend.Services.Interfaces
{
    public interface IGroupService
    {
        Task<OperationResult> AddGroupAsync(Group group);
        Task<List<Group>> GetGroupsAsync();
        Task<Group?> GetGroupAsync(int id);
        Task<OperationResult> UpdateGroupAsync(int id, Group group);
        Task<OperationResult> RemoveGroupAsync(int id);
    }
}
