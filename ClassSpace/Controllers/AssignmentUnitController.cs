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
        public List<AssignmentUnit> GetAssignmentUnits()
        {
            return assignmentUnitRepository.GetAssignmentUnits();
        }

        // GET api/AssignmentUnit/3/7
        [HttpGet("{assignmentId}/{unitId}")]
        public ActionResult<AssignmentUnit> GetAssignmentUnit(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = assignmentUnitRepository.GetAssignmentUnit(assignmentId, unitId);
            if (assignmentUnit == null)
                return NotFound();
            return assignmentUnit;
        }

        // GET api/AssignmentUnit/assignment/3 - על אילו יחידות המטלה
        [HttpGet("assignment/{assignmentId}")]
        public List<AssignmentUnit> GetUnitsByAssignment(int assignmentId)
        {
            return assignmentUnitRepository.GetUnitsByAssignment(assignmentId);
        }

        // POST api/AssignmentUnit
        [HttpPost]
        public AssignmentUnit AddAssignmentUnit(AssignmentUnit assignmentUnit)
        {
            return assignmentUnitRepository.AddAssignmentUnit(assignmentUnit);
        }

        // DELETE api/AssignmentUnit/3/7
        [HttpDelete("{assignmentId}/{unitId}")]
        public ActionResult DeleteAssignmentUnit(int assignmentId, int unitId)
        {
            if (!assignmentUnitRepository.DeleteAssignmentUnit(assignmentId, unitId))
                return NotFound();
            return Ok();
        }
    }
}
