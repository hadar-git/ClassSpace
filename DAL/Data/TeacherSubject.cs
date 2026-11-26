using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class TeacherSubject
    {
        public int TeacherSubjectId { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int LessonID { get; set; }

        public User? Teacher { get; set; }
        public Subject? Subject { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
