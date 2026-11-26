using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        // GET api/Subject
        [HttpGet]
        public async Task<List<Subject>> GetSubjects()
        {
            return await subjectRepository.GetSubjectsAsync();
        }

        // GET api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            Subject subject = await subjectRepository.GetSubjectAsync(id);
            if (subject == null)
                return NotFound();
            return subject;
        }

        // POST api/Subject
        [HttpPost]
        public async Task<Subject> AddSubject(Subject subject)
        {
            return await subjectRepository.AddSubjectAsync(subject);
        }

        // PUT api/Subject
        [HttpPut]
        public async Task<Subject> UpdateSubject(Subject subject)
        {
            return await subjectRepository.UpdateSubjectAsync(subject);
        }

        // DELETE api/Subject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            if (!await subjectRepository.DeleteSubjectAsync(id))
                return NotFound();
            return Ok();
        }
    }
}