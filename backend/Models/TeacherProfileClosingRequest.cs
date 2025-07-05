namespace backend.Models
{
    public class TeacherProfileClosingRequest
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Reason { get; set; } = "";
        public string? AdditionalInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
