using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // GET api/Subject
        [HttpGet]
        public List<Subject> GetSubjects()
        {
            return _subjectRepository.GetSubjects();
        }

        // GET api/Subject/5
        [HttpGet("{id}")]
        public ActionResult<Subject> GetSubject(int id)
        {
            Subject subject = _subjectRepository.GetSubject(id);
            if (subject == null)
                return NotFound();
            return subject;
        }

        // POST api/Subject
        [HttpPost]
        public Subject AddSubject(Subject subject)
        {
            return _subjectRepository.AddSubject(subject);
        }

        // PUT api/Subject
        [HttpPut]
        public Subject UpdateSubject(Subject subject)
        {
            return _subjectRepository.UpdateSubject(subject);
        }

        // DELETE api/Subject/5
        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            if (!_subjectRepository.DeleteSubject(id))
                return NotFound();
            return Ok();
        }
    }
}
