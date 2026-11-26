using AutoMapper;
using DAL.Data;
using DAL.Repositories;
using DTO;

namespace BLL.Services
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository materialRepository;
        private IMapper mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            this.materialRepository = materialRepository;
            this.mapper = mapper;
        }

        public async Task<List<MaterialDto>> GetMaterialsAsync()
        {
            List<Material> materials = await materialRepository.GetMaterialsAsync();
            return mapper.Map<List<MaterialDto>>(materials);
        }

        public async Task<MaterialDto?> GetMaterialAsync(int id)
        {
            Material material = await materialRepository.GetMaterialAsync(id);
            if (material == null)
                return null;
            return mapper.Map<MaterialDto>(material);
        }

        public async Task<MaterialDto> AddMaterialAsync(MaterialPostDto materialDto)
        {
            Material material = mapper.Map<Material>(materialDto);
            material.UploadedAt = DateTime.Now;
            await materialRepository.AddMaterialAsync(material);
            Material saved = await materialRepository.GetMaterialAsync(material.MaterialId);
            return mapper.Map<MaterialDto>(saved);
        }

        public async Task<bool> UpdateMaterialAsync(int id, MaterialUpdateDto materialDto)
        {
            Material material = await materialRepository.GetMaterialAsync(id);
            if (material == null)
                return false;
            mapper.Map(materialDto, material);
            await materialRepository.UpdateMaterialAsync(material);
            return true;
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            return await materialRepository.DeleteMaterialAsync(id);
        }

        public async Task<List<MaterialDto>> GetMaterialsByUnitAsync(int unitId)
        {
            List<Material> materials = await materialRepository.GetMaterialsByUnitAsync(unitId);
            return mapper.Map<List<MaterialDto>>(materials);
        }

        public async Task<List<MaterialDto>> GetMaterialsByAssignmentAsync(int assignmentId)
        {
            List<Material> materials = await materialRepository.GetMaterialsByAssignmentAsync(assignmentId);
            return mapper.Map<List<MaterialDto>>(materials);
        }

        public async Task<List<MaterialDto>> GetMaterialsByQuestionAsync(int questionId)
        {
            List<Material> materials = await materialRepository.GetMaterialsByQuestionAsync(questionId);
            return mapper.Map<List<MaterialDto>>(materials);
        }
    }
}
