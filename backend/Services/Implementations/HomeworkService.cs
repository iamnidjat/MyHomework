using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Implementations
{
    public class HomeworkService : IHomeworkService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<HomeworkService> _logger;

        public HomeworkService(MyHomeworkDbContext context, ILogger<HomeworkService> logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> AddHomeworkAsync(Homework homework)
        {
            try
            {
                await _context.Homeworks.AddAsync(homework);
                await _context.SaveChangesAsync();
                return new OperationResult { Success = true };
            }
            catch(Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to add homework");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex) // general fallback for unexpected exceptions
            {
                _logger.LogError(ex, "Unexpected error occurred while adding homework.");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<Homework>> GetHomeworksAsync()
        {
            try
            {
                return await _context.Homeworks.AsNoTracking().ToListAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get homeworks");
                return Enumerable.Empty<Homework>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting homeworks.");
                return Enumerable.Empty<Homework>().ToList();
            }
        }

        public async Task<Homework?> GetHomeworkAsync(int id)
        {
            try
            {
                return await _context.Homeworks
                    .AsNoTracking()
                    .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get homework with ID {HomeworkId}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting homework with ID {HomeworkId}", id);
                return null;
            }
        }

        public async Task<OperationResult> UpdateHomeworkAsync(int id, Homework newHomework)
        {
            try
            {
                var homework = await FindHomeworkAsync(id);

                if (homework != null)
                {
                    homework.Title = newHomework.Title;
                    homework.Description = newHomework.Description;       
                    homework.IssuedTime = newHomework.IssuedTime;
                    homework.Deadline = newHomework.Deadline;

                    await _context.SaveChangesAsync();

                    return new OperationResult { Success = true };
                }
                return new OperationResult { Success = false, ErrorMessage = $"homework with ID {id} not found" };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update homework with ID {HomeworkId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Unexpected error occurred while adding homework with ID {HomeworkId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> RemoveHomeworkAsync(int id)
        {
            try
            {
                var homework = await FindHomeworkAsync(id);

                if (homework != null)
                {
                    _context.Homeworks.Remove(homework);

                    await _context.SaveChangesAsync();

                    return new OperationResult { Success = true };
                }
                return new OperationResult { Success = false, ErrorMessage = $"homework with ID {id} not found" };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to remove homework with ID {HomeworkId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while removing homework with ID {HomeworkId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        private async Task<Homework?> FindHomeworkAsync(int id)
        {
            return await _context.Homeworks.FindAsync(id);
        }
    }
}
