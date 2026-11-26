using DAL.Data;
using BLL.Services;
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
        public async Task<List<Material>> GetMaterials()
        {
            return await materialService.GetMaterialsAsync();
        }

        // GET api/Material/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            Material material = await materialService.GetMaterialAsync(id);
            if (material == null)
                return NotFound();
            return material;
        }

        // GET api/Material/unit/5 - החומרים של יחידה
        [HttpGet("unit/{unitId}")]
        public async Task<List<Material>> GetMaterialsByUnit(int unitId)
        {
            return await materialService.GetMaterialsByUnitAsync(unitId);
        }

        // GET api/Material/assignment/5 - החומרים של מטלה
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<Material>> GetMaterialsByAssignment(int assignmentId)
        {
            return await materialService.GetMaterialsByAssignmentAsync(assignmentId);
        }

        // GET api/Material/question/5 - החומרים של שאלה
        [HttpGet("question/{questionId}")]
        public async Task<List<Material>> GetMaterialsByQuestion(int questionId)
        {
            return await materialService.GetMaterialsByQuestionAsync(questionId);
        }

        // POST api/Material
        [HttpPost]
        public async Task<Material> AddMaterial(Material material)
        {
            return await materialService.AddMaterialAsync(material);
        }

        // PUT api/Material
        [HttpPut]
        public async Task<Material> UpdateMaterial(Material material)
        {
            return await materialService.UpdateMaterialAsync(material);
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
