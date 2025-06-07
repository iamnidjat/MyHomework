using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        public int? TeacherProfileId { get; set; }

        public TeacherProfile? TeacherProfile { get; set; }

        public ICollection<GroupHomework> GroupHomeworks { get; set; } = new List<GroupHomework>();
    }
}
