using DTO;

namespace BLL.Services
{
    public interface IAssignmentService
    {
        Task<List<AssignmentDto>> GetAssignmentsAsync();
        Task<AssignmentDto?> GetAssignmentAsync(int id);
        Task<AssignmentDto> AddAssignmentAsync(AssignmentPostDto assignmentDto);
        Task<bool> UpdateAssignmentAsync(int id, AssignmentUpdateDto assignmentDto);
        Task<bool> DeleteAssignmentAsync(int id);
        Task<List<AssignmentDto>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId);
    }
}
