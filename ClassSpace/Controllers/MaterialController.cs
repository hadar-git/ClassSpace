using BLL.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        // GET api/Material
        [HttpGet]
        public async Task<List<MaterialDto>> GetMaterials()
        {
            return await materialService.GetMaterialsAsync();
        }

        // GET api/Material/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDto>> GetMaterial(int id)
        {
            MaterialDto? material = await materialService.GetMaterialAsync(id);
            if (material == null)
                return NotFound();
            return material;
        }

        // GET api/Material/unit/5
        [HttpGet("unit/{unitId}")]
        public async Task<List<MaterialDto>> GetMaterialsByUnit(int unitId)
        {
            return await materialService.GetMaterialsByUnitAsync(unitId);
        }

        // GET api/Material/assignment/5
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<MaterialDto>> GetMaterialsByAssignment(int assignmentId)
        {
            return await materialService.GetMaterialsByAssignmentAsync(assignmentId);
        }

        // GET api/Material/question/5
        [HttpGet("question/{questionId}")]
        public async Task<List<MaterialDto>> GetMaterialsByQuestion(int questionId)
        {
            return await materialService.GetMaterialsByQuestionAsync(questionId);
        }

        // POST api/Material
        [HttpPost]
        public async Task<MaterialDto> AddMaterial(MaterialPostDto materialDto)
        {
            return await materialService.AddMaterialAsync(materialDto);
        }

        // PUT api/Material/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaterial(int id, MaterialUpdateDto materialDto)
        {
            if (!await materialService.UpdateMaterialAsync(id, materialDto))
                return NotFound();
            return NoContent();
        }

        // DELETE api/Material/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            if (!await materialService.DeleteMaterialAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
