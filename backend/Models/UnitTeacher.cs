namespace backend.Models
{
    public class UnitTeacher
    {
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }

        public int TeacherId { get; set; }
        public TeacherProfile? Teacher { get; set; }
    }
}
