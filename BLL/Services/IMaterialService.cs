using DAL.Data;

namespace BLL.Services
{
    public interface IMaterialService
    {
        Task<List<Material>> GetMaterialsAsync();
        Task<Material> GetMaterialAsync(int id);
        Task<Material> AddMaterialAsync(Material material);
        Task<Material> UpdateMaterialAsync(Material material);
        Task<bool> DeleteMaterialAsync(int id);
        Task<List<Material>> GetMaterialsByUnitAsync(int unitId);
        Task<List<Material>> GetMaterialsByAssignmentAsync(int assignmentId);
        Task<List<Material>> GetMaterialsByQuestionAsync(int questionId);
    }
}
