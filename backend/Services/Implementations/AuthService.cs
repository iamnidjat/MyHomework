using backend.DTOs;
using backend.Models;
using backend.Services.Interfaces;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace backend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly MyHomeworkDbContext _context;
        private readonly ILogger<AuthService> _logger;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            MyHomeworkDbContext context,
            ILogger<AuthService> logger,
            IJwtTokenService jwtTokenService)
        {
            _context = context;
            _logger = logger;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthResponseDto?> StudentLoginAsync(string username, string password)
        {
            try
            {
                var student = await _context.StudentProfiles.FirstOrDefaultAsync(u => u.Username == username);

                if (student == null || !BC.EnhancedVerify(password, student.Password, HashType.SHA512))
                {
                    return null;
                }

                var token = _jwtTokenService.GenerateToken(student.Id.ToString(), student.Username);

                return new AuthResponseDto
                {
                    Token = token,
                    UserId = student.Id,
                    Username = student.Username,
                    Email = student.Email,
                    Birthday = student.Birthday,
                    UserType = student.UserType,
                };
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to log in");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while logging");
                return null;
            }
        }

        public async Task<AuthResponseDto?> StudentSignupAsync(string username, string password, string confirmPassword, string email, DateTime birthday)
        {
            try
            {
                var student = await _context.StudentProfiles.FirstOrDefaultAsync(u => u.Username == username);

                if (student != null)
                {
                    _logger.LogWarning($"Student {student} already exists");
                    return null;
                }

                _context.StudentProfiles.Add(new StudentProfile
                {
                    Username = username,
                    Password = BC.EnhancedHashPassword(password, 13, HashType.SHA512),
                    Email = email,
                    Birthday = birthday,
                });

                await _context.SaveChangesAsync();

                var token = _jwtTokenService.GenerateToken(student.Id.ToString(), student.Username);

                return new AuthResponseDto
                {
                    Token = token,
                    UserId = student.Id,
                    Username = student.Username,
                    Email = student.Email,
                    Birthday = student.Birthday,
                    UserType = student.UserType,
                };
            }
            catch (Exception ex) when (ex is ArgumentNullException or OperationCanceledException)
            {
                _logger.LogError(ex, "Failed to sign up");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while signing up");
                return null;
            }
        }
    }
}
