using backend.DTOs;

namespace backend.Services.Interfaces
{
    public interface IAuthService
    {
        string GetRandomUsername();
        Task<AuthResponseDto?> StudentLoginAsync(string username, string password);
        Task<AuthResponseDto?> StudentSignupAsync(string username, string password, string confirmPassword, string email, DateTime birthday);
        Task<bool?> IsStudentProfileFrozenAsync(string username);
    }
}
