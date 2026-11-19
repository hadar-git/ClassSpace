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

        // GET api/Question/unit/5 - השאלות של יחידת לימוד (בשביל האלגוריתם)
        [HttpGet("unit/{unitId}")]
        public List<Question> GetQuestionsByUnit(int unitId)
        {
            return questionRepository.GetQuestionsByUnit(unitId);
        }

        // GET api/Question/teacherSubject/5 - השאלות שמגיעות למורה במקצוע ובכיתה
        [HttpGet("teacherSubject/{teacherSubjectId}")]
        public List<Question> GetQuestionsByTeacherSubject(int teacherSubjectId)
        {
            return questionRepository.GetQuestionsByTeacherSubject(teacherSubjectId);
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
