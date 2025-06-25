using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Implementations
{
    public class InteractionService : IInteractionService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<InteractionService> _logger;
        public InteractionService(MyHomeworkDbContext context, ILogger<InteractionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> SendFeedbackAsync(Feedback feedback)
        {
            try
            {
                await _context.Feedbacks.AddAsync(feedback);
                await _context.SaveChangesAsync();
                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to send feedback");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex) // general fallback for unexpected exceptions
            {
                _logger.LogError(ex, "Unexpected error occurred while sending feedback");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<Feedback>> GetAllFeedbacksByHomeworkAsync(int id)
        {
            try
            {
                return await _context.Feedbacks.AsNoTracking().Where(h => h.HomeworkId == id).ToListAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get feedbacks");
                return Enumerable.Empty<Feedback>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting feedbacks");
                return Enumerable.Empty<Feedback>().ToList();
            }
        }

        public async Task<Feedback?> GetFeedbackByIdAsync(int id)
        {
            try
            {
                return await _context.Feedbacks.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get feedback with ID {EntityId}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting feedback with ID {EntityId}", id);
                return null;
            }
        }
    }
}
