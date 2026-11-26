using DAL.Data;

namespace DAL.Repositories
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetLessonsAsync();            // כל הכיתות
        Task<Lesson> GetLessonAsync(int id);             // כיתה לפי קוד
        Task<Lesson> AddLessonAsync(Lesson lesson);      // הוספה
        Task<Lesson> UpdateLessonAsync(Lesson lesson);   // עדכון
        Task<bool> DeleteLessonAsync(int id);            // מחיקה לפי קוד
    }
}