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
        public List<Material> GetMaterials()
        {
            return materialRepository.GetMaterials();
        }

        // GET api/Material/5
        [HttpGet("{id}")]
        public ActionResult<Material> GetMaterial(int id)
        {
            Material material = materialRepository.GetMaterial(id);
            if (material == null)
                return NotFound();
            return material;
        }

        // GET api/Material/unit/5 - החומרים של יחידה
        [HttpGet("unit/{unitId}")]
        public List<Material> GetMaterialsByUnit(int unitId)
        {
            return materialRepository.GetMaterialsByUnit(unitId);
        }

        // GET api/Material/assignment/5 - החומרים של מטלה
        [HttpGet("assignment/{assignmentId}")]
        public List<Material> GetMaterialsByAssignment(int assignmentId)
        {
            return materialRepository.GetMaterialsByAssignment(assignmentId);
        }

        // GET api/Material/question/5 - החומרים של שאלה
        [HttpGet("question/{questionId}")]
        public List<Material> GetMaterialsByQuestion(int questionId)
        {
            return materialRepository.GetMaterialsByQuestion(questionId);
        }

        // POST api/Material
        [HttpPost]
        public Material AddMaterial(Material material)
        {
            return materialRepository.AddMaterial(material);
        }

        // PUT api/Material
        [HttpPut]
        public Material UpdateMaterial(Material material)
        {
            return materialRepository.UpdateMaterial(material);
        }

        // DELETE api/Material/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMaterial(int id)
        {
            if (!materialRepository.DeleteMaterial(id))
                return NotFound();
            return Ok();
        }
    }
}
