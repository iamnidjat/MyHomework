using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Homework : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "IssuedTime is required")]
        public DateTime IssuedTime { get; set; }

        [Required(ErrorMessage = "Deadline is required")]
        public DateTime Deadline { get; set; }

        public ICollection<GroupHomework> GroupHomeworks { get; set; } = new List<GroupHomework>();
    }
}
