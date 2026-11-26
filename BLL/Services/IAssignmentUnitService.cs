using DTO;

namespace BLL.Services
{
    public interface IAssignmentUnitService
    {
        Task<List<AssignmentUnitDto>> GetAssignmentUnitsAsync();
        Task<AssignmentUnitDto?> GetAssignmentUnitAsync(int assignmentId, int unitId);
        Task<List<AssignmentUnitDto>> GetUnitsByAssignmentAsync(int assignmentId);
        Task<AssignmentUnitDto> AddAssignmentUnitAsync(AssignmentUnitPostDto assignmentUnitDto);
        Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId);
    }
}
