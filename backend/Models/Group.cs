using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Group : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        public int? TeacherProfileId { get; set; }

        public bool IsPublic { get; set; } = false;

        public TeacherProfile? TeacherProfile { get; set; }

        public ICollection<GroupHomework> GroupHomeworks { get; set; } = new List<GroupHomework>();
    }
}
