namespace backend.Models
{
    public class GroupHomework
    {
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        public int HomeworkId { get; set; }
        public Homework? Homework { get; set; } 
    }
}
