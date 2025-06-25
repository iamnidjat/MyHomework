using backend.DTOs;

namespace backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> StudentLoginAsync(string username, string password);
        Task<AuthResponseDto?> StudentSignupAsync(string username, string password, string confirmPassword, string email, DateTime birthday);
    }
}
