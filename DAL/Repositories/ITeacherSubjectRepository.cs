using DAL.Data;

namespace DAL.Repositories
{
    public interface ITeacherSubjectRepository
    {
        List<TeacherSubject> GetTeacherSubjects();                   // כל השיוכים
        TeacherSubject GetTeacherSubject(int id);                    // שיוך לפי קוד
        TeacherSubject AddTeacherSubject(TeacherSubject ts);         // הוספה
        bool DeleteTeacherSubject(int id);                           // מחיקה לפי קוד

        // לפי הצרכים של הפרויקט
        List<TeacherSubject> GetByTeacher(int teacherId);            // אילו מקצועות מלמדת מורה
        List<TeacherSubject> GetBySubject(int subjectId);            // אילו מורות מלמדות מקצוע
        List<TeacherSubject> GetByLesson(int lessonId);                // מה לומדים בכיתה
    }
}
