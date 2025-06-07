using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Group = backend.Models.Group;

namespace backend.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<GroupService> _logger;

        public GroupService(MyHomeworkDbContext context, ILogger<GroupService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> AddGroupAsync(Group group)
        {
            try
            {
                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();
                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to add group");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex) // general fallback for unexpected exceptions
            {
                _logger.LogError(ex, "Unexpected error occurred while adding group.");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            try
            {
                return await _context.Groups.AsNoTracking().ToListAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get groups");
                return Enumerable.Empty<Group>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting grpups.");
                return Enumerable.Empty<Group>().ToList();
            }
        }

        public async Task<Group?> GetGroupAsync(int id)
        {
            try
            {
                return await _context.Groups
                    .AsNoTracking()
                    .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to get group with ID {GroupId}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting group with ID {GroupId}", id);
                return null;
            }
        }

        public async Task<OperationResult> UpdateGroupAsync(int id, Group newGroup)
        {
            try
            {
                var group = await FindGroupAsync(id);

                if (group != null)
                {
                    group.Name = newGroup.Name;
                    group.Description = newGroup.Description;
                    group.TeacherProfileId = newGroup.TeacherProfileId;

                    await _context.SaveChangesAsync();

                    return new OperationResult { Success = true };
                }
                return new OperationResult { Success = false, ErrorMessage = $"group with ID {id} not found" };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update group with ID {GroupId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while adding group with ID {GroupId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> RemoveGroupAsync(int id)
        {
            try
            {
                var group = await FindGroupAsync(id);

                if (group != null)
                {
                    _context.Groups.Remove(group);

                    await _context.SaveChangesAsync();

                    return new OperationResult { Success = true };
                }
                return new OperationResult { Success = false, ErrorMessage = $"group with ID {id} not found" };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to remove group with ID {GroupId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while removing group with ID {GroupId}", id);
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        private async Task<Group?> FindGroupAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }
    }
}
