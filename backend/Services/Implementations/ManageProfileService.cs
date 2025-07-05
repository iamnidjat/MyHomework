using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Implementations
{
    public class ManageProfileService : IManageProfileService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<ManageProfileService> _logger;
        public ManageProfileService(MyHomeworkDbContext context, ILogger<ManageProfileService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> UpdateStudentProfileAsync(int id, StudentProfile updatedProfile)
        {
            try
            {
                var existingProfile = await _context.StudentProfiles.FindAsync(id);

                if (existingProfile == null)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Student profile not found." };
                }

                existingProfile.Name = updatedProfile.Name;
                existingProfile.Birthday = updatedProfile.Birthday;

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while updating student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> UpdateTeacherProfileAsync(int id, TeacherProfile updatedProfile)
        {
            try
            {
                var existingProfile = await _context.StudentProfiles.FindAsync(id);

                if (existingProfile == null)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Teacher profile not found." };
                }

                existingProfile.Name = updatedProfile.Name;
                existingProfile.Birthday = updatedProfile.Birthday;

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update teacher profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while updating teacher profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> UpdateUsernameAsync(int id, string newUsername, string userType)
        {
            try
            {
                if (userType == "student")
                {
                    var profile = await _context.StudentProfiles.FindAsync(id);
                    if (profile == null)
                        return new OperationResult { Success = false, ErrorMessage = "Student profile not found." };

                    profile.Username = newUsername;
                }
                else if (userType == "teacher")
                {
                    var profile = await _context.TeacherProfiles.FindAsync(id);
                    if (profile == null)
                        return new OperationResult { Success = false, ErrorMessage = "Teacher profile not found." };

                    profile.Username = newUsername;
                }
                else
                {
                    return new OperationResult { Success = false, ErrorMessage = "Invalid user type." };
                }

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update username");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while updating username");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> UpdateEmailAsync(int id, string newEmail, string userType, bool flag)
        {
            try
            {
                if (userType == "student")
                {
                    var profile = await _context.StudentProfiles.FindAsync(id);
                    if (profile == null)
                        return new OperationResult { Success = false, ErrorMessage = "Student profile not found." };
                 
                    if (flag)
                    {
                        profile.Email = newEmail;
                        // send an email
                    }
                    else
                    {
                        profile.BackUpEmail = newEmail;
                        //if (newEmail != "")
                        //{
                        //    // send an email
                        //}
                    }
                }
                else if (userType == "teacher")
                {
                    var profile = await _context.TeacherProfiles.FindAsync(id);
                    if (profile == null)
                        return new OperationResult { Success = false, ErrorMessage = "Teacher profile not found." };

                    if (flag)
                    {
                        profile.Email = newEmail;
                        // send an email
                    }
                    else
                    {
                        profile.BackUpEmail = newEmail;
                        //if (newEmail != "")
                        //{
                        //    // send an email
                        //}
                    }
                }
                else
                {
                    return new OperationResult { Success = false, ErrorMessage = "Invalid user type." };
                }

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to update email");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while updating email");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> DeleteStudentProfileAsync(int id)
        {
            try
            {
                var profile = await _context.StudentProfiles.FindAsync(id);

                if (profile == null)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Student profile not found." };
                }

                _context.StudentProfiles.Remove(profile);

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to delete student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while deleting student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> FreezeStudentProfileAsync(int id)
        {
            try
            {
                var profile = await _context.StudentProfiles.FindAsync(id);

                if (profile == null)
                {
                    return new OperationResult { Success = false, ErrorMessage = "Student profile not found." };
                }

                profile.IsFrozen = true;

                await _context.SaveChangesAsync();

                return new OperationResult { Success = true };
            }
            catch (Exception ex) when (ex is DbUpdateConcurrencyException or DbUpdateException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to freeze student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while freezing student profile");
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}
