using DAL.Data;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }

        // GET api/Assignment
        [HttpGet]
        public async Task<List<Assignment>> GetAssignments()
        {
            return await assignmentService.GetAssignmentsAsync();
        }

        // GET api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            Assignment assignment = await assignmentService.GetAssignmentAsync(id);
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // GET api/Assignment/teacherSubject/5 - המטלות של מורה+מקצוע+כיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<Assignment>> GetAssignmentsByTeacherSubject(int teacherSubjectId)
        {
            return await assignmentService.GetAssignmentsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Assignment
        [HttpPost]
        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            return await assignmentService.AddAssignmentAsync(assignment);
        }

        // PUT api/Assignment
        [HttpPut]
        public async Task<Assignment> UpdateAssignment(Assignment assignment)
        {
            return await assignmentService.UpdateAssignmentAsync(assignment);
        }

        // DELETE api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            if (!await assignmentService.DeleteAssignmentAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
