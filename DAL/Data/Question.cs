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
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int VotesCount { get; set; }

        public int StudentID { get; set; }
        public User? Student { get; set; }

        public int TeacherID { get; set; }
        public User? Teacher { get; set; }

        public int SubjectID { get; set; }
        public Subject? Subject { get; set; }
    }
}
