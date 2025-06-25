using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Feedback
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = "";

        [Required(ErrorMessage = "SendAt is required")]
        public DateTime SendAt { get; set; }

        [Required(ErrorMessage = "HomeworkId is required")]
        public int? HomeworkId { get; set; }
        public Homework? Homework { get; set; }
    }
}
