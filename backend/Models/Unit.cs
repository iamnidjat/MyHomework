using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Unit : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();

        public ICollection<UnitTeacher> UnitTeachers { get; set; } = new List<UnitTeacher>();
    }
}
