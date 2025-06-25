using backend.Models;
using backend.Utilities;

namespace backend.Services.Interfaces
{
    public interface IInteractionService
    {
        Task<OperationResult> SendFeedbackAsync(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacksByHomeworkAsync(int id);
        Task<Feedback?> GetFeedbackByIdAsync(int id);
    }
}
