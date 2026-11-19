namespace DAL.Data
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public string? FilePath { get; set; }

        public int TeacherSubjectID { get; set; }
        public TeacherSubject? TeacherSubject { get; set; }
    }
}
