namespace backend.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? TeacherProfileId {  get; set; }

        public ICollection<UnitTeacher> UnitTeachers { get; set; } = new List<UnitTeacher>();
    }
}
