using DTO;

namespace BLL.Services
{
    public interface IMaterialService
    {
        Task<List<MaterialDto>> GetMaterialsAsync();
        Task<MaterialDto?> GetMaterialAsync(int id);
        Task<MaterialDto> AddMaterialAsync(MaterialPostDto materialDto);
        Task<bool> UpdateMaterialAsync(int id, MaterialUpdateDto materialDto);
        Task<bool> DeleteMaterialAsync(int id);
        Task<List<MaterialDto>> GetMaterialsByUnitAsync(int unitId);
        Task<List<MaterialDto>> GetMaterialsByAssignmentAsync(int assignmentId);
        Task<List<MaterialDto>> GetMaterialsByQuestionAsync(int questionId);
    }
}
