using DAL.Data;

namespace DAL.Repositories
{
    public interface ILessonRepository
    {
        List<Lesson> GetLessons();         // כל הכיתות
        Lesson GetLesson(int id);           // כיתה לפי קוד
        Lesson AddLesson(Lesson lesson);      // הוספה
        Lesson UpdateLesson(Lesson lesson);   // עדכון
        bool DeleteLesson(int id);         // מחיקה לפי קוד
    }
}
