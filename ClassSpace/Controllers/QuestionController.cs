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
        public List<Question> GetQuestions()
        {
            return questionRepository.GetQuestions();
        }

        // GET api/Question/5
        [HttpGet("{id}")]
        public ActionResult<Question> GetQuestion(int id)
        {
            Question question = questionRepository.GetQuestion(id);
            if (question == null)
                return NotFound();
            return question;
        }

        // GET api/Question/teacher/2
        [HttpGet("teacher/{teacherId}")]
        public List<Question> GetQuestionsByTeacher(int teacherId)
        {
            return questionRepository.GetQuestionsByTeacher(teacherId);
        }

        // POST api/Question
        [HttpPost]
        public Question AddQuestion(Question question)
        {
            return questionRepository.AddQuestion(question);
        }

        // PUT api/Question
        [HttpPut]
        public Question UpdateQuestion(Question question)
        {
            return questionRepository.UpdateQuestion(question);
        }

        // DELETE api/Question/5
        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            if (!questionRepository.DeleteQuestion(id))
                return NotFound();
            return Ok();
        }
    }
}
