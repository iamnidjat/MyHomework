namespace backend.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime IssuedTime { get; set; }

        public DateTime Deadline { get; set; }
    }
}
