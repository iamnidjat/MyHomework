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

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
