namespace backend.Models
{
    public class UnitTeacher
    {
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }

        public int TeacherProfileId { get; set; }
        public TeacherProfile? TeacherProfile { get; set; }
    }
}
