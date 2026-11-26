using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentRepository assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        // GET api/Assignment
        [HttpGet]
        public async Task<List<Assignment>> GetAssignments()
        {
            return await assignmentRepository.GetAssignmentsAsync();
        }

        // GET api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            Assignment assignment = await assignmentRepository.GetAssignmentAsync(id);
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // GET api/Assignment/teacherSubject/5 - המטלות של מורה+מקצוע+כיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<Assignment>> GetAssignmentsByTeacherSubject(int teacherSubjectId)
        {
            return await assignmentRepository.GetAssignmentsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Assignment
        [HttpPost]
        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            return await assignmentRepository.AddAssignmentAsync(assignment);
        }

        // PUT api/Assignment
        [HttpPut]
        public async Task<Assignment> UpdateAssignment(Assignment assignment)
        {
            return await assignmentRepository.UpdateAssignmentAsync(assignment);
        }

        // DELETE api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            if (!await assignmentRepository.DeleteAssignmentAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
