using backend.DTOs;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace backend.Services.Implementations
{
    public class StatisticsService : IStatisticsService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<StatisticsService> _logger;
        public StatisticsService(MyHomeworkDbContext context, ILogger<StatisticsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<StudentStatsDto>> GetStudentsStatsAsync()
        {
            try
            {
                return await _context.StudentProfiles
                            .AsNoTracking()
                            .Select(s => new StudentStatsDto
                            {
                                Id = s.Id,
                                Username = s.Username!,
                                AverageGrade = s.Grades.Any() ? s.Grades.Average(g => g.Mark) : 0
                            })
                            .OrderByDescending(s => s.AverageGrade)
                            .ToListAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get students stats");
                return Enumerable.Empty<StudentStatsDto>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting students stats");
                return Enumerable.Empty<StudentStatsDto>().ToList();
            }
        }
    }
}
