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
        public async Task<List<TeacherSubject>> GetTeacherSubjectsAsync()
        {
            return await db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .Include(ts => ts.Lesson)
                .ToListAsync();
        }

        public async Task<TeacherSubject> GetTeacherSubjectAsync(int id)
        {
            return await db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .Include(ts => ts.Lesson)
                .FirstOrDefaultAsync(ts => ts.TeacherSubjectId == id);
        }

        public async Task<TeacherSubject> AddTeacherSubjectAsync(TeacherSubject ts)
        {
            await db.TeacherSubjects.AddAsync(ts);
            await db.SaveChangesAsync();
            return ts;
        }

        public async Task<bool> DeleteTeacherSubjectAsync(int id)
        {
            TeacherSubject ts = await db.TeacherSubjects.FirstOrDefaultAsync(t => t.TeacherSubjectId == id);
            if (ts == null)
                return false;
            db.TeacherSubjects.Remove(ts);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<TeacherSubject>> GetByTeacherAsync(int teacherId)
        {
            return await db.TeacherSubjects
                .Include(ts => ts.Subject)
                .Include(ts => ts.Lesson)
                .Where(ts => ts.TeacherID == teacherId)
                .ToListAsync();
        }

        public async Task<List<TeacherSubject>> GetBySubjectAsync(int subjectId)
        {
            return await db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Lesson)
                .Where(ts => ts.SubjectID == subjectId)
                .ToListAsync();
        }

        public async Task<List<TeacherSubject>> GetByLessonAsync(int lessonId)
        {
            return await db.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .Where(ts => ts.LessonID == lessonId)
                .ToListAsync();
        }
    }
}