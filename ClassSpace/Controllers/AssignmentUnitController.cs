using DAL.Data;
using BLL.Services;
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
        public async Task<List<AssignmentUnit>> GetAssignmentUnits()
        {
            return await assignmentUnitService.GetAssignmentUnitsAsync();
        }

        // GET api/AssignmentUnit/3/7
        [HttpGet("{assignmentId}/{unitId}")]
        public async Task<ActionResult<AssignmentUnit>> GetAssignmentUnit(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = await assignmentUnitService.GetAssignmentUnitAsync(assignmentId, unitId);
            if (assignmentUnit == null)
                return NotFound();
            return assignmentUnit;
        }

        // GET api/AssignmentUnit/assignment/3 - על אילו יחידות המטלה
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<AssignmentUnit>> GetUnitsByAssignment(int assignmentId)
        {
            return await assignmentUnitService.GetUnitsByAssignmentAsync(assignmentId);
        }

        // POST api/AssignmentUnit
        [HttpPost]
        public async Task<AssignmentUnit> AddAssignmentUnit(AssignmentUnit assignmentUnit)
        {
            return await assignmentUnitService.AddAssignmentUnitAsync(assignmentUnit);
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
