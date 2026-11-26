using BLL.Services;
using DTO;
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
        public async Task<List<QuestionDto>> GetQuestions()
        {
            return await questionService.GetQuestionsAsync();
        }

        // GET api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            QuestionDto? question = await questionService.GetQuestionAsync(id);
            if (question == null)
                return NotFound();
            return question;
        }

        // GET api/Question/unit/5
        [HttpGet("unit/{unitId}")]
        public async Task<List<QuestionDto>> GetQuestionsByUnit(int unitId)
        {
            return await questionService.GetQuestionsByUnitAsync(unitId);
        }

        // GET api/Question/teacherSubject/5
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public async Task<List<QuestionDto>> GetQuestionsByTeacherSubject(int teacherSubjectId)
        {
            return await questionService.GetQuestionsByTeacherSubjectAsync(teacherSubjectId);
        }

        // POST api/Question
        [HttpPost]
        public async Task<QuestionDto> AddQuestion(QuestionPostDto questionDto)
        {
            return await questionService.AddQuestionAsync(questionDto);
        }

        // PUT api/Question/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuestion(int id, QuestionUpdateDto questionDto)
        {
            if (!await questionService.UpdateQuestionAsync(id, questionDto))
                return NotFound();
            return NoContent();
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
