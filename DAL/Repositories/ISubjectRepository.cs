using DAL.Data;

namespace DAL.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetSubjectsAsync();             // כל המקצועות
        Task<Subject> GetSubjectAsync(int id);              // מקצוע לפי קוד
        Task<Subject> AddSubjectAsync(Subject subject);     // הוספה
        Task<Subject> UpdateSubjectAsync(Subject subject);  // עדכון
        Task<bool> DeleteSubjectAsync(int id);              // מחיקה לפי קוד
    }
}