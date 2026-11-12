using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        private ClassSpaceDB db;

        public TeacherSubjectRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        // Include = להביא יחד עם השיוך גם את המורה והמקצוע עצמם (כמו אצל המורה עם Category)
        public List<TeacherSubject> GetTeacherSubjects()
        {
            return db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .ToList();
        }

        public TeacherSubject GetTeacherSubject(int id)
        {
            return db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .FirstOrDefault(ts => ts.TeacherSubjectId == id);
        }

        public TeacherSubject AddTeacherSubject(TeacherSubject ts)
        {
            db.TeacherSubjects.Add(ts);
            db.SaveChanges();
            return ts;
        }

        public bool DeleteTeacherSubject(int id)
        {
            TeacherSubject ts = db.TeacherSubjects.FirstOrDefault(t => t.TeacherSubjectId == id);
            if (ts == null)
                return false;
            db.TeacherSubjects.Remove(ts);
            db.SaveChanges();
            return true;
        }

        public List<TeacherSubject> GetByTeacher(int teacherId)
        {
            return db.TeacherSubjects
                .Include(ts => ts.Subject)
                .Where(ts => ts.TeacherID == teacherId)
                .ToList();
        }

        public List<TeacherSubject> GetBySubject(int subjectId)
        {
            return db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Where(ts => ts.SubjectID == subjectId)
                .ToList();
        }
    }
}
