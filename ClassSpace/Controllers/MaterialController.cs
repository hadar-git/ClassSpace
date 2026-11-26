using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialRepository materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        // GET api/Material
        [HttpGet]
        public async Task<List<Material>> GetMaterials()
        {
            return await materialRepository.GetMaterialsAsync();
        }

        // GET api/Material/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            Material material = await materialRepository.GetMaterialAsync(id);
            if (material == null)
                return NotFound();
            return material;
        }

        // GET api/Material/unit/5 - החומרים של יחידה
        [HttpGet("unit/{unitId}")]
        public async Task<List<Material>> GetMaterialsByUnit(int unitId)
        {
            return await materialRepository.GetMaterialsByUnitAsync(unitId);
        }

        // GET api/Material/assignment/5 - החומרים של מטלה
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<Material>> GetMaterialsByAssignment(int assignmentId)
        {
            return await materialRepository.GetMaterialsByAssignmentAsync(assignmentId);
        }

        // GET api/Material/question/5 - החומרים של שאלה
        [HttpGet("question/{questionId}")]
        public async Task<List<Material>> GetMaterialsByQuestion(int questionId)
        {
            return await materialRepository.GetMaterialsByQuestionAsync(questionId);
        }

        // POST api/Material
        [HttpPost]
        public async Task<Material> AddMaterial(Material material)
        {
            return await materialRepository.AddMaterialAsync(material);
        }

        // PUT api/Material
        [HttpPut]
        public async Task<Material> UpdateMaterial(Material material)
        {
            return await materialRepository.UpdateMaterialAsync(material);
        }

        // DELETE api/Material/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            if (!await materialRepository.DeleteMaterialAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
