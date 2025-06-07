using backend.Utilities;

namespace backend.Services.Interfaces
{
    public interface ICRUDBaseService<T> where T : class
    {
        Task<OperationResult> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<OperationResult> UpdateAsync(int id, T updatedEntity);
        Task<OperationResult> RemoveAsync(int id);
    }
}
