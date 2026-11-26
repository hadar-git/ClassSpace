namespace DTO
{
    public class AssignmentPostDto
    {
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? FilePath { get; set; }
        public int TeacherSubjectID { get; set; }
    }
}
