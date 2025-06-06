namespace backend.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int TeacherProfileId {  get; set; }

        public TeacherProfile? TeacherProfile { get; set; }
    }
}
