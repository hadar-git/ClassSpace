using DAL.Data;

namespace DAL.Repositories
{
    public interface IAssignmentRepository
    {
        List<Assignment> GetAssignments();                                       // כל המטלות
        Assignment GetAssignment(int id);                                        // מטלה לפי קוד
        Assignment AddAssignment(Assignment assignment);                         // הוספה
        Assignment UpdateAssignment(Assignment assignment);                      // עדכון
        bool DeleteAssignment(int id);                                           // מחיקה לפי קוד
        List<Assignment> GetAssignmentsByTeacherSubject(int teacherSubjectId);   // המטלות של מורה+מקצוע+כיתה
    }
}
