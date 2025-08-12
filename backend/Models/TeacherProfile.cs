using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TeacherProfile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = "";

        public string? Name { get; set; }

        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [EmailAddress]
        public string? BackUpEmail { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public DateTime Birthday { get; set; }

        public string UserType { get; } = "teacher";

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
        public ICollection<UnitTeacher> UnitTeachers { get; set; } = new List<UnitTeacher>();
    }
}
