using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        [Required]
        public DateTime IssuedTime { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public ICollection<GroupHomework> GroupHomeworks { get; set; } = new List<GroupHomework>();
    }
}
