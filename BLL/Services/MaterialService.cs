using DAL.Data;
using DAL.Repositories;

namespace BLL.Services
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<List<Material>> GetMaterialsAsync()
        {
            return await materialRepository.GetMaterialsAsync();
        }

        public async Task<Material> GetMaterialAsync(int id)
        {
            return await materialRepository.GetMaterialAsync(id);
        }

        public async Task<Material> AddMaterialAsync(Material material)
        {
            return await materialRepository.AddMaterialAsync(material);
        }

        public async Task<Material> UpdateMaterialAsync(Material material)
        {
            return await materialRepository.UpdateMaterialAsync(material);
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            return await materialRepository.DeleteMaterialAsync(id);
        }

        public async Task<List<Material>> GetMaterialsByUnitAsync(int unitId)
        {
            return await materialRepository.GetMaterialsByUnitAsync(unitId);
        }

        public async Task<List<Material>> GetMaterialsByAssignmentAsync(int assignmentId)
        {
            return await materialRepository.GetMaterialsByAssignmentAsync(assignmentId);
        }

        public async Task<List<Material>> GetMaterialsByQuestionAsync(int questionId)
        {
            return await materialRepository.GetMaterialsByQuestionAsync(questionId);
        }
    }
}
