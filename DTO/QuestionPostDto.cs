namespace DTO
{
    public class QuestionPostDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int StudentID { get; set; }
        public int TeacherSubjectID { get; set; }
        public int UnitID { get; set; }
        public int? AssignmentID { get; set; }
    }
}
