using AutoMapper;
using DAL.Data;
using DAL.Repositories;
using DTO;

namespace BLL.Services
{
    public class AssignmentUnitService : IAssignmentUnitService
    {
        private IAssignmentUnitRepository assignmentUnitRepository;
        private IMapper mapper;

        public AssignmentUnitService(IAssignmentUnitRepository assignmentUnitRepository, IMapper mapper)
        {
            this.assignmentUnitRepository = assignmentUnitRepository;
            this.mapper = mapper;
        }

        public async Task<List<AssignmentUnitDto>> GetAssignmentUnitsAsync()
        {
            List<AssignmentUnit> assignmentUnits = await assignmentUnitRepository.GetAssignmentUnitsAsync();
            return mapper.Map<List<AssignmentUnitDto>>(assignmentUnits);
        }

        public async Task<AssignmentUnitDto?> GetAssignmentUnitAsync(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = await assignmentUnitRepository.GetAssignmentUnitAsync(assignmentId, unitId);
            if (assignmentUnit == null)
                return null;
            return mapper.Map<AssignmentUnitDto>(assignmentUnit);
        }

        public async Task<List<AssignmentUnitDto>> GetUnitsByAssignmentAsync(int assignmentId)
        {
            List<AssignmentUnit> assignmentUnits = await assignmentUnitRepository.GetUnitsByAssignmentAsync(assignmentId);
            return mapper.Map<List<AssignmentUnitDto>>(assignmentUnits);
        }

        public async Task<AssignmentUnitDto> AddAssignmentUnitAsync(AssignmentUnitPostDto assignmentUnitDto)
        {
            AssignmentUnit assignmentUnit = mapper.Map<AssignmentUnit>(assignmentUnitDto);
            await assignmentUnitRepository.AddAssignmentUnitAsync(assignmentUnit);
            AssignmentUnit saved = await assignmentUnitRepository.GetAssignmentUnitAsync(assignmentUnit.AssignmentID, assignmentUnit.UnitID);
            return mapper.Map<AssignmentUnitDto>(saved);
        }

        public async Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId)
        {
            return await assignmentUnitRepository.DeleteAssignmentUnitAsync(assignmentId, unitId);
        }
    }
}
