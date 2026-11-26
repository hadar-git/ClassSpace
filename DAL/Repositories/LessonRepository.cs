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

        public List<Lesson> GetLessons()
        {
            return db.Lessons
                .ToList();
        }

        public Lesson GetLesson(int id)
        {
            return db.Lessons
                .FirstOrDefault(c => c.LessonId == id);
        }

        public Lesson AddLesson(Lesson lesson)
        {
            db.Lessons.Add(lesson);
            db.SaveChanges();
            return lesson;
        }

        public Lesson UpdateLesson(Lesson lesson)
        {
            db.Lessons.Update(lesson);
            db.SaveChanges();
            return lesson;
        }

        public bool DeleteLesson(int id)
        {
            Lesson lesson = db.Lessons.FirstOrDefault(c => c.LessonId == id);
            if (lesson == null)
                return false;
            db.Lessons.Remove(lesson);
            db.SaveChanges();
            return true;
        }
    }
}
