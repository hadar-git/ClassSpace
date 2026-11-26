using DAL.Data;

namespace BLL.Services
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAssignmentsAsync();
        Task<Assignment> GetAssignmentAsync(int id);
        Task<Assignment> AddAssignmentAsync(Assignment assignment);
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);
        Task<bool> DeleteAssignmentAsync(int id);
        Task<List<Assignment>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId);
    }
}
