namespace backend.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = "";
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserType { get; set; } = "";
        public DateTime Birthday { get; set; }
    }
}
