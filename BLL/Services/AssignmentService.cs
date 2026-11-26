using DAL.Data;
using DAL.Repositories;

namespace BLL.Services
{
    public class AssignmentService : IAssignmentService
    {
        private IAssignmentRepository assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await assignmentRepository.GetAssignmentsAsync();
        }

        public async Task<Assignment> GetAssignmentAsync(int id)
        {
            return await assignmentRepository.GetAssignmentAsync(id);
        }

        public async Task<Assignment> AddAssignmentAsync(Assignment assignment)
        {
            return await assignmentRepository.AddAssignmentAsync(assignment);
        }

        public async Task<Assignment> UpdateAssignmentAsync(Assignment assignment)
        {
            return await assignmentRepository.UpdateAssignmentAsync(assignment);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            return await assignmentRepository.DeleteAssignmentAsync(id);
        }

        public async Task<List<Assignment>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId)
        {
            return await assignmentRepository.GetAssignmentsByTeacherSubjectAsync(teacherSubjectId);
        }
    }
}
