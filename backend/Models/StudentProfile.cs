using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        public string Name { get; set; } = "";

        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [EmailAddress]
        public string? BackUpEmail { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public string UserType { get; } = "student";

        public DateTime Birthday { get; set; }

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
