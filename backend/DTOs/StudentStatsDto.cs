using backend.Models;

namespace backend.DTOs
{
    public class StudentStatsDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public double AverageGrade { get; set; }
    }
}
