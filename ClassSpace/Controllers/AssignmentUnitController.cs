using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentUnitController : ControllerBase
    {
        private IAssignmentUnitRepository assignmentUnitRepository;

        public AssignmentUnitController(IAssignmentUnitRepository assignmentUnitRepository)
        {
            this.assignmentUnitRepository = assignmentUnitRepository;
        }

        // GET api/AssignmentUnit
        [HttpGet]
        public async Task<List<AssignmentUnit>> GetAssignmentUnits()
        {
            return await assignmentUnitRepository.GetAssignmentUnitsAsync();
        }

        // GET api/AssignmentUnit/3/7
        [HttpGet("{assignmentId}/{unitId}")]
        public async Task<ActionResult<AssignmentUnit>> GetAssignmentUnit(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = await assignmentUnitRepository.GetAssignmentUnitAsync(assignmentId, unitId);
            if (assignmentUnit == null)
                return NotFound();
            return assignmentUnit;
        }

        // GET api/AssignmentUnit/assignment/3 - על אילו יחידות המטלה
        [HttpGet("assignment/{assignmentId}")]
        public async Task<List<AssignmentUnit>> GetUnitsByAssignment(int assignmentId)
        {
            return await assignmentUnitRepository.GetUnitsByAssignmentAsync(assignmentId);
        }

        // POST api/AssignmentUnit
        [HttpPost]
        public async Task<AssignmentUnit> AddAssignmentUnit(AssignmentUnit assignmentUnit)
        {
            return await assignmentUnitRepository.AddAssignmentUnitAsync(assignmentUnit);
        }

        // DELETE api/AssignmentUnit/3/7
        [HttpDelete("{assignmentId}/{unitId}")]
        public async Task<ActionResult> DeleteAssignmentUnit(int assignmentId, int unitId)
        {
            if (!await assignmentUnitRepository.DeleteAssignmentUnitAsync(assignmentId, unitId))
                return NotFound();
            return Ok();
        }
    }
}
