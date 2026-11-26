using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private ClassSpaceDB db;

        public LessonRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<Lesson>> GetLessonsAsync()
        {
            return await db.Lessons
                .ToListAsync();
        }

        public async Task<Lesson> GetLessonAsync(int id)
        {
            return await db.Lessons
                .FirstOrDefaultAsync(c => c.LessonId == id);
        }

        public async Task<Lesson> AddLessonAsync(Lesson lesson)
        {
            await db.Lessons.AddAsync(lesson);
            await db.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
        {
            db.Lessons.Update(lesson);
            await db.SaveChangesAsync();
            return lesson;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            Lesson lesson = await db.Lessons.FirstOrDefaultAsync(c => c.LessonId == id);
            if (lesson == null)
                return false;

            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();
            return true;
        }
    }
}