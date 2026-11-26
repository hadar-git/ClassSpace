using DAL.Data;

namespace DAL.Repositories
{
    public interface ITeacherSubjectRepository
    {
        Task<List<TeacherSubject>> GetTeacherSubjectsAsync();                   // כל השיוכים
        Task<TeacherSubject> GetTeacherSubjectAsync(int id);                    // שיוך לפי קוד
        Task<TeacherSubject> AddTeacherSubjectAsync(TeacherSubject ts);         // הוספה
        Task<bool> DeleteTeacherSubjectAsync(int id);                           // מחיקה לפי קוד

        // לפי הצרכים של הפרויקט
        Task<List<TeacherSubject>> GetByTeacherAsync(int teacherId);            // אילו מקצועות מלמדת מורה
        Task<List<TeacherSubject>> GetBySubjectAsync(int subjectId);            // אילו מורות מלמדות מקצוע
        Task<List<TeacherSubject>> GetByLessonAsync(int lessonId);              // מה לומדים בכיתה
    }
}