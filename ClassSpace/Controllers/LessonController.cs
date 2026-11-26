using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonRepository lessonRepository;

        public LessonController(ILessonRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        // GET api/Lesson
        [HttpGet]
        public List<Lesson> GetLessons()
        {
            return lessonRepository.GetLessons();
        }

        // GET api/Lesson/5
        [HttpGet("{id}")]
        public ActionResult<Lesson> GetLesson(int id)
        {
            Lesson lesson = lessonRepository.GetLesson(id);
            if (lesson == null)
                return NotFound();
            return lesson;
        }

        // POST api/Lesson
        [HttpPost]
        public Lesson AddLesson(Lesson lesson)
        {
            return lessonRepository.AddLesson(lesson);
        }

        // PUT api/Lesson
        [HttpPut]
        public Lesson UpdateLesson(Lesson lesson)
        {
            return lessonRepository.UpdateLesson(lesson);
        }

        // DELETE api/Lesson/5
        [HttpDelete("{id}")]
        public ActionResult DeleteLesson(int id)
        {
            if (!lessonRepository.DeleteLesson(id))
                return NotFound();
            return Ok();
        }
    }
}
