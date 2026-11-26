using DAL.Data;

namespace BLL.Services
{
    public interface IAssignmentUnitService
    {
        Task<List<AssignmentUnit>> GetAssignmentUnitsAsync();
        Task<AssignmentUnit> GetAssignmentUnitAsync(int assignmentId, int unitId);
        Task<List<AssignmentUnit>> GetUnitsByAssignmentAsync(int assignmentId);
        Task<AssignmentUnit> AddAssignmentUnitAsync(AssignmentUnit assignmentUnit);
        Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId);
    }
}
