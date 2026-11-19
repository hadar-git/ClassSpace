using DAL.Data;

namespace DAL.Repositories
{
    public interface ISubjectRepository
    {
        List<Subject> GetSubjects();             // כל המקצועות
        Subject GetSubject(int id);              // מקצוע לפי קוד
        Subject AddSubject(Subject subject);     // הוספה
        Subject UpdateSubject(Subject subject);  // עדכון
        bool DeleteSubject(int id);              // מחיקה לפי קוד
    }
}
