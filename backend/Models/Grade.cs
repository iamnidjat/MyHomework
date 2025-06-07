using backend.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Grade : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Mark {  get; set; } = 0;
            
        [Required]
        public int? UnitId { get; set; }

        public Unit? Unit { get; set; }

        [Required]
        public int? StudentId { get; set; }

        public StudentProfile? StudentProfile { get; set; }
    }
}
