using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private ClassSpaceDB db;

        public SubjectRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await db.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectAsync(int id)
        {
            return await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            await db.Subjects.AddAsync(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            db.Subjects.Update(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            Subject subject = await GetSubjectAsync(id);
            if (subject == null)
                return false;
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return true;
        }
    }
}