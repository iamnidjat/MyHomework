using backend.Models;
using backend.Utilities;

namespace backend.Services.Interfaces
{
    public interface IHomeworkService
    {
        Task<OperationResult> AddHomeworkAsync(Homework homework);
        Task<List<Homework>> GetHomeworksAsync();
        Task<Homework?> GetHomeworkAsync(int id);
        Task<OperationResult> UpdateHomeworkAsync(int id, Homework newHomework);
        Task<OperationResult> RemoveHomeworkAsync(int id);
    }
}
