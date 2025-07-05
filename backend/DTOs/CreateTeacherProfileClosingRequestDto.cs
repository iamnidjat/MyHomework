namespace backend.DTOs
{
    public class CreateTeacherProfileClosingRequestDto
    {
        public string Username { get; set; } = "";
        public string Reason { get; set; } = "";
        public string? AdditionalInfo { get; set; }
    }
}
