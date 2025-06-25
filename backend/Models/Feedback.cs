using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Feedback
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = "";

        [Required]
        public string Type { get; set; } = ""; 

        [Required]
        public DateTime SendAt { get; set; }
    }
}
