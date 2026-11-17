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
        public List<Assignment> GetAssignments()
        {
            return assignmentRepository.GetAssignments();
        }

        // GET api/Assignment/5
        [HttpGet("{id}")]
        public ActionResult<Assignment> GetAssignment(int id)
        {
            Assignment assignment = assignmentRepository.GetAssignment(id);
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // GET api/Assignment/teacherSubject/5 - המטלות של מורה+מקצוע+כיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public List<Assignment> GetAssignmentsByTeacherSubject(int teacherSubjectId)
        {
            return assignmentRepository.GetAssignmentsByTeacherSubject(teacherSubjectId);
        }

        // POST api/Assignment
        [HttpPost]
        public Assignment AddAssignment(Assignment assignment)
        {
            return assignmentRepository.AddAssignment(assignment);
        }

        // PUT api/Assignment
        [HttpPut]
        public Assignment UpdateAssignment(Assignment assignment)
        {
            return assignmentRepository.UpdateAssignment(assignment);
        }

        // DELETE api/Assignment/5
        [HttpDelete("{id}")]
        public ActionResult DeleteAssignment(int id)
        {
            if (!assignmentRepository.DeleteAssignment(id))
                return NotFound();
            return Ok();
        }
    }
}
