using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "HomeworkId is required")]
        public int HomeworkId { get; set; }
        public Homework? Homework { get; set; }

        public int? StudentProfileId { get; set; }
        public StudentProfile? StudentProfile { get; set; }

        public int? TeacherProfileId { get; set; }
        public TeacherProfile? TeacherProfile { get; set; }
    }
}
