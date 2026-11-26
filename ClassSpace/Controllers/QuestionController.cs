using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        // GET api/Question
        [HttpGet]
        public async Task<List<Question>> GetQuestions()
        {
            return await questionRepository.GetQuestionsAsync();
        }

        // GET api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            Question question = await questionRepository.GetQuestionAsync(id);
            if (question == null)
                return NotFound();
            return question;
        }

        // GET api/Question/unit/5 - השאלות של יחידת לימוד (בשביל האלגוריתם)
        [HttpGet("unit/{unitId}")]
        public async Task<List<Question>> GetQuestionsByUnit(int unitId)
        {
            return await questionRepository.GetQuestionsByUnitAsync(unitId);
        }

        // GET api/Question/teacherSubject/5 - השאלות שמגיעות למורה במקצוע ובכיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<Question>> GetQuestionsByTeacherSubject(int teacherSubjectId)
        {
            return await questionRepository.GetQuestionsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Question
        [HttpPost]
        public async Task<Question> AddQuestion(Question question)
        {
            return await questionRepository.AddQuestionAsync(question);
        }

        // PUT api/Question
        [HttpPut]
        public async Task<Question> UpdateQuestion(Question question)
        {
            return await questionRepository.UpdateQuestionAsync(question);
        }

        // DELETE api/Question/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            if (!await questionRepository.DeleteQuestionAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
