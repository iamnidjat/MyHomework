using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Grade : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mark is required")]
        public float Mark {  get; set; } = 0;
            
        [Required(ErrorMessage = "UnitId is required")]
        public int? UnitId { get; set; }

        public Unit? Unit { get; set; }

        [Required(ErrorMessage = "StudentId is required")]
        public int? StudentId { get; set; }

        public StudentProfile? StudentProfile { get; set; }
    }
}
