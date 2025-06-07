using backend.Models.Base;

namespace backend.Models
{
    public class Unit : IEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        //public int? TeacherProfileId {  get; set; }

        //public TeacherProfile? TeacherProfile { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();

        public ICollection<UnitTeacher> UnitTeachers { get; set; } = new List<UnitTeacher>();
    }
}
