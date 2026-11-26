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
        public async Task<List<Lesson>> GetLessons()
        {
            return await lessonRepository.GetLessonsAsync();
        }

        // GET api/Lesson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            Lesson lesson = await lessonRepository.GetLessonAsync(id);
            if (lesson == null)
                return NotFound();
            return lesson;
        }

        // POST api/Lesson
        [HttpPost]
        public async Task<Lesson> AddLesson(Lesson lesson)
        {
            return await lessonRepository.AddLessonAsync(lesson);
        }

        // PUT api/Lesson
        [HttpPut]
        public async Task<Lesson> UpdateLesson(Lesson lesson)
        {
            return await lessonRepository.UpdateLessonAsync(lesson);
        }

        // DELETE api/Lesson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            if (!await lessonRepository.DeleteLessonAsync(id))
                return NotFound();
            return Ok();
        }
    }
}