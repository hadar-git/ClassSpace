using DAL.Data;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        // GET api/Question
        [HttpGet]
        public async Task<List<Question>> GetQuestions()
        {
            return await questionService.GetQuestionsAsync();
        }

        // GET api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            Question question = await questionService.GetQuestionAsync(id);
            if (question == null)
                return NotFound();
            return question;
        }

        // GET api/Question/unit/5 - השאלות של יחידת לימוד (בשביל האלגוריתם)
        [HttpGet("unit/{unitId}")]
        public async Task<List<Question>> GetQuestionsByUnit(int unitId)
        {
            return await questionService.GetQuestionsByUnitAsync(unitId);
        }

        // GET api/Question/teacherSubject/5 - השאלות שמגיעות למורה במקצוע ובכיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<Question>> GetQuestionsByTeacherSubject(int teacherSubjectId)
        {
            return await questionService.GetQuestionsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Question
        [HttpPost]
        public async Task<Question> AddQuestion(Question question)
        {
            return await questionService.AddQuestionAsync(question);
        }

        // PUT api/Question
        [HttpPut]
        public async Task<Question> UpdateQuestion(Question question)
        {
            return await questionService.UpdateQuestionAsync(question);
        }

        // DELETE api/Question/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            if (!await questionService.DeleteQuestionAsync(id))
                return NotFound();
            return Ok();
        }
    }
}
