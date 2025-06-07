using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TeacherProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = "";

        public string? Name { get; set; }

        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [EmailAddress]
        public string? BackUpEmail { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public DateTime Birthday { get; set; }

        public ICollection<Group> Groups { get; set; } = new List<Group>();

       // public ICollection<Unit> Units { get; set; } = new List<Unit>();

        public ICollection<UnitTeacher> UnitTeachers { get; set; } = new List<UnitTeacher>();
    }
}
