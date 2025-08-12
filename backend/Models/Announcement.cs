using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Announcement : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "IssuedTime is required")]
        public DateTime IssuedTime { get; set; }
        public int TeacherProfileId { get; set; }
        public TeacherProfile? TeacherProfile { get; set; }
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
