using DAL.Data;

namespace DAL.Repositories
{
    public interface IAssignmentUnitRepository
    {
        List<AssignmentUnit> GetAssignmentUnits();                          // כל הקישורים
        AssignmentUnit GetAssignmentUnit(int assignmentId, int unitId);     // קישור אחד
        List<AssignmentUnit> GetUnitsByAssignment(int assignmentId);        // על אילו יחידות המטלה
        AssignmentUnit AddAssignmentUnit(AssignmentUnit assignmentUnit);    // הוספה
        bool DeleteAssignmentUnit(int assignmentId, int unitId);            // מחיקה
    }
}
