using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private ITeacherSubjectRepository teacherSubjectRepository;

        public TeacherSubjectController(ITeacherSubjectRepository teacherSubjectRepository)
        {
            this.teacherSubjectRepository = teacherSubjectRepository;
        }

        // GET api/TeacherSubject
        [HttpGet]
        public List<TeacherSubject> GetTeacherSubjects()
        {
            return teacherSubjectRepository.GetTeacherSubjects();
        }

        // GET api/TeacherSubject/5
        [HttpGet("{id}")]
        public ActionResult<TeacherSubject> GetTeacherSubject(int id)
        {
            TeacherSubject ts = teacherSubjectRepository.GetTeacherSubject(id);
            if (ts == null)
                return NotFound();
            return ts;
        }

        // GET api/TeacherSubject/teacher/5 - המקצועות של מורה
        [HttpGet("teacher/{teacherId}")]
        public List<TeacherSubject> GetByTeacher(int teacherId)
        {
            return teacherSubjectRepository.GetByTeacher(teacherId);
        }

        // GET api/TeacherSubject/subject/5 - המורות של מקצוע
        [HttpGet("subject/{subjectId}")]
        public List<TeacherSubject> GetBySubject(int subjectId)
        {
            return teacherSubjectRepository.GetBySubject(subjectId);
        }

        // GET api/TeacherSubject/lesson/5 - מה לומדים בכיתה
        [HttpGet("lesson/{lessonId}")]
        public List<TeacherSubject> GetByLesson(int lessonId)
        {
            return teacherSubjectRepository.GetByLesson(lessonId);
        }

        // POST api/TeacherSubject
        [HttpPost]
        public TeacherSubject AddTeacherSubject(TeacherSubject ts)
        {
            return teacherSubjectRepository.AddTeacherSubject(ts);
        }

        // DELETE api/TeacherSubject/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacherSubject(int id)
        {
            if (!teacherSubjectRepository.DeleteTeacherSubject(id))
                return NotFound();
            return Ok();
        }
    }
}
