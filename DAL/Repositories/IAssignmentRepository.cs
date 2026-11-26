using DAL.Data;

namespace DAL.Repositories
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAssignmentsAsync();                                       // כל המטלות
        Task<Assignment> GetAssignmentAsync(int id);                                        // מטלה לפי קוד
        Task<Assignment> AddAssignmentAsync(Assignment assignment);                         // הוספה
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);                      // עדכון
        Task<bool> DeleteAssignmentAsync(int id);                                           // מחיקה לפי קוד
        Task<List<Assignment>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId);   // המטלות של מורה+מקצוע+כיתה
    }
}
