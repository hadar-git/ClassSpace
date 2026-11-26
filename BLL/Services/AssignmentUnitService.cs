using DAL.Data;
using DAL.Repositories;

namespace BLL.Services
{
    public class AssignmentUnitService : IAssignmentUnitService
    {
        private IAssignmentUnitRepository assignmentUnitRepository;

        public AssignmentUnitService(IAssignmentUnitRepository assignmentUnitRepository)
        {
            this.assignmentUnitRepository = assignmentUnitRepository;
        }

        public async Task<List<AssignmentUnit>> GetAssignmentUnitsAsync()
        {
            return await assignmentUnitRepository.GetAssignmentUnitsAsync();
        }

        public async Task<AssignmentUnit> GetAssignmentUnitAsync(int assignmentId, int unitId)
        {
            return await assignmentUnitRepository.GetAssignmentUnitAsync(assignmentId, unitId);
        }

        public async Task<List<AssignmentUnit>> GetUnitsByAssignmentAsync(int assignmentId)
        {
            return await assignmentUnitRepository.GetUnitsByAssignmentAsync(assignmentId);
        }

        public async Task<AssignmentUnit> AddAssignmentUnitAsync(AssignmentUnit assignmentUnit)
        {
            return await assignmentUnitRepository.AddAssignmentUnitAsync(assignmentUnit);
        }

        public async Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId)
        {
            return await assignmentUnitRepository.DeleteAssignmentUnitAsync(assignmentId, unitId);
        }
    }
}
