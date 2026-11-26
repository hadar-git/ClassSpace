namespace DTO
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string? AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AnsweredAt { get; set; }
        public int StudentID { get; set; }
        public string StudentFullName { get; set; }
        public int TeacherSubjectID { get; set; }
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public int? AssignmentID { get; set; }
    }
}
