using AutoMapper;
using DAL.Data;
using DAL.Repositories;
using DTO;

namespace BLL.Services
{
    public class AssignmentService : IAssignmentService
    {
        private IAssignmentRepository assignmentRepository;
        private IMapper mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.mapper = mapper;
        }

        public async Task<List<AssignmentDto>> GetAssignmentsAsync()
        {
            List<Assignment> assignments = await assignmentRepository.GetAssignmentsAsync();
            return mapper.Map<List<AssignmentDto>>(assignments);
        }

        public async Task<AssignmentDto?> GetAssignmentAsync(int id)
        {
            Assignment assignment = await assignmentRepository.GetAssignmentAsync(id);
            if (assignment == null)
                return null;
            return mapper.Map<AssignmentDto>(assignment);
        }

        public async Task<AssignmentDto> AddAssignmentAsync(AssignmentPostDto assignmentDto)
        {
            Assignment assignment = mapper.Map<Assignment>(assignmentDto);
            assignment.CreatedAt = DateTime.Now;
            await assignmentRepository.AddAssignmentAsync(assignment);
            return mapper.Map<AssignmentDto>(assignment);
        }

        public async Task<bool> UpdateAssignmentAsync(int id, AssignmentUpdateDto assignmentDto)
        {
            Assignment assignment = await assignmentRepository.GetAssignmentAsync(id);
            if (assignment == null)
                return false;
            mapper.Map(assignmentDto, assignment);
            await assignmentRepository.UpdateAssignmentAsync(assignment);
            return true;
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            return await assignmentRepository.DeleteAssignmentAsync(id);
        }

        public async Task<List<AssignmentDto>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId)
        {
            List<Assignment> assignments = await assignmentRepository.GetAssignmentsByTeacherSubjectAsync(teacherSubjectId);
            return mapper.Map<List<AssignmentDto>>(assignments);
        }
    }
}
