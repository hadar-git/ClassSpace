using DAL.Data;

namespace DAL.Repositories
{
    public interface IAssignmentUnitRepository
    {
        Task<List<AssignmentUnit>> GetAssignmentUnitsAsync();                          // כל הקישורים
        Task<AssignmentUnit> GetAssignmentUnitAsync(int assignmentId, int unitId);     // קישור אחד
        Task<List<AssignmentUnit>> GetUnitsByAssignmentAsync(int assignmentId);        // על אילו יחידות המטלה
        Task<AssignmentUnit> AddAssignmentUnitAsync(AssignmentUnit assignmentUnit);    // הוספה
        Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId);            // מחיקה
    }
}
