namespace backend.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userId, string username);
    }
}
