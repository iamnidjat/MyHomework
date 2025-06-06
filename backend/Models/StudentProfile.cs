using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        public string Name { get; set; } = "";

        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        public string? BackUpEmail { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public DateTime Birthday { get; set; }
    }
}
