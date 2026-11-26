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
        public async Task<List<TeacherSubject>> GetTeacherSubjects()
        {
            return await teacherSubjectRepository.GetTeacherSubjectsAsync();
        }

        // GET api/TeacherSubject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherSubject>> GetTeacherSubject(int id)
        {
            TeacherSubject ts = await teacherSubjectRepository.GetTeacherSubjectAsync(id);
            if (ts == null)
                return NotFound();
            return ts;
        }

        // GET api/TeacherSubject/teacher/5 - המקצועות של מורה
        [HttpGet("teacher/{teacherId}")]
        public async Task<List<TeacherSubject>> GetByTeacher(int teacherId)
        {
            return await teacherSubjectRepository.GetByTeacherAsync(teacherId);
        }

        // GET api/TeacherSubject/subject/5 - המורות של מקצוע
        [HttpGet("subject/{subjectId}")]
        public async Task<List<TeacherSubject>> GetBySubject(int subjectId)
        {
            return await teacherSubjectRepository.GetBySubjectAsync(subjectId);
        }

        // GET api/TeacherSubject/lesson/5 - מה לומדים בכיתה
        [HttpGet("lesson/{lessonId}")]
        public async Task<List<TeacherSubject>> GetByLesson(int lessonId)
        {
            return await teacherSubjectRepository.GetByLessonAsync(lessonId);
        }

        // POST api/TeacherSubject
        [HttpPost]
        public async Task<TeacherSubject> AddTeacherSubject(TeacherSubject ts)
        {
            return await teacherSubjectRepository.AddTeacherSubjectAsync(ts);
        }

        // DELETE api/TeacherSubject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherSubject(int id)
        {
            if (!await teacherSubjectRepository.DeleteTeacherSubjectAsync(id))
                return NotFound();
            return Ok();
        }
    }
}