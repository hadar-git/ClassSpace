using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string? AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AnsweredAt { get; set; }

        public int StudentID { get; set; }
        public User? Student { get; set; }

        public int TeacherSubjectID { get; set; }
        public TeacherSubject? TeacherSubject { get; set; }

        public int? AssignmentID { get; set; }
        public Assignment? Assignment { get; set; }

        public int UnitID { get; set; }
        public StudyUnit? Unit { get; set; }
    }
}
