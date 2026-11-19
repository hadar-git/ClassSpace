using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public List<TeacherSubject>? TeacherSubjects { get; set; }

    }
}
