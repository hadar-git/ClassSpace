using BLL.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentUnitController : ControllerBase
    {
        private IAssignmentUnitService assignmentUnitService;

        public AssignmentUnitController(IAssignmentUnitService assignmentUnitService)
        {
            this.assignmentUnitService = assignmentUnitService;
        }

        // GET api/AssignmentUnit
        [HttpGet]
        public async Task<List<AssignmentUnitDto>> GetAssignmentUnits()
        {
            return await assignmentUnitService.GetAssignmentUnitsAsync();
        }

        // GET api/AssignmentUnit/3/7
        [HttpGet("{assignmentId}/{unitId}")]
        public async Task<ActionResult<AssignmentUnitDto>> GetAssignmentUnit(int assignmentId, int unitId)
        {
            AssignmentUnitDto? assignmentUnit = await assignmentUnitService.GetAssignmentUnitAsync(assignmentId, unitId);
            if (assignmentUnit == null)
                return NotFound();
            return assignmentUnit;
        }

        // GET api/AssignmentUnit/assignment/3
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<AssignmentUnitDto>> GetUnitsByAssignment(int assignmentId)
        {
            return await assignmentUnitService.GetUnitsByAssignmentAsync(assignmentId);
        }

        // POST api/AssignmentUnit
        [HttpPost]
        public async Task<AssignmentUnitDto> AddAssignmentUnit(AssignmentUnitPostDto assignmentUnitDto)
        {
            return await assignmentUnitService.AddAssignmentUnitAsync(assignmentUnitDto);
        }

        // DELETE api/AssignmentUnit/3/7
        [HttpDelete("{assignmentId}/{unitId}")]
        public async Task<ActionResult> DeleteAssignmentUnit(int assignmentId, int unitId)
        {
            if (!await assignmentUnitService.DeleteAssignmentUnitAsync(assignmentId, unitId))
                return NotFound();
            return Ok();
        }
    }
}
