using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public enum Role { Admin = 1, Teacher, Student }
    public class User
    {

        
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }
        public Role Role { get; set; }


        public List<TeacherSubject> TeacherSubjects { get; set; }
    }
}
