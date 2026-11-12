using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private ITeacherSubjectRepository _teacherSubjectRepository;

        public TeacherSubjectController(ITeacherSubjectRepository teacherSubjectRepository)
        {
            _teacherSubjectRepository = teacherSubjectRepository;
        }

        // GET api/TeacherSubject
        [HttpGet]
        public List<TeacherSubject> GetTeacherSubjects()
        {
            return _teacherSubjectRepository.GetTeacherSubjects();
        }

        // GET api/TeacherSubject/5
        [HttpGet("{id}")]
        public ActionResult<TeacherSubject> GetTeacherSubject(int id)
        {
            TeacherSubject ts = _teacherSubjectRepository.GetTeacherSubject(id);
            if (ts == null)
                return NotFound();
            return ts;
        }

        // GET api/TeacherSubject/teacher/5 - המקצועות של מורה
        [HttpGet("teacher/{teacherId}")]
        public List<TeacherSubject> GetByTeacher(int teacherId)
        {
            return _teacherSubjectRepository.GetByTeacher(teacherId);
        }

        // GET api/TeacherSubject/subject/5 - המורות של מקצוע
        [HttpGet("subject/{subjectId}")]
        public List<TeacherSubject> GetBySubject(int subjectId)
        {
            return _teacherSubjectRepository.GetBySubject(subjectId);
        }

        // POST api/TeacherSubject
        [HttpPost]
        public TeacherSubject AddTeacherSubject(TeacherSubject ts)
        {
            return _teacherSubjectRepository.AddTeacherSubject(ts);
        }

        // DELETE api/TeacherSubject/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacherSubject(int id)
        {
            if (!_teacherSubjectRepository.DeleteTeacherSubject(id))
                return NotFound();
            return Ok();
        }
    }
}
