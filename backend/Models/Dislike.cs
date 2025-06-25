using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Dislike
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "HomeworkId is required")]
        public int HomeworkId { get; set; }

        public Homework? Homework { get; set; }
    }
}
