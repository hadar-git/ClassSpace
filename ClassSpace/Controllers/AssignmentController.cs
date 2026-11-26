using BLL.Services;
using DTO;
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
        public async Task<List<AssignmentDto>> GetAssignments()
        {
            return await assignmentService.GetAssignmentsAsync();
        }

        // GET api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            AssignmentDto? assignment = await assignmentService.GetAssignmentAsync(id);
            if (assignment == null)
                return NotFound();
            return assignment;
        }

        // GET api/Assignment/teacherSubject/5
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<AssignmentDto>> GetAssignmentsByTeacherSubject(int teacherSubjectId)
        {
            return await assignmentService.GetAssignmentsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Assignment
        [HttpPost]
        public async Task<AssignmentDto> AddAssignment(AssignmentPostDto assignmentDto)
        {
            return await assignmentService.AddAssignmentAsync(assignmentDto);
        }

        // PUT api/Assignment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAssignment(int id, AssignmentUpdateDto assignmentDto)
        {
            if (!await assignmentService.UpdateAssignmentAsync(id, assignmentDto))
                return NotFound();
            return NoContent();
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
