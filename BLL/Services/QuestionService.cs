using AutoMapper;
using DAL.Data;
using DAL.Repositories;
using DTO;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepository;
        private IMapper mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        public async Task<List<QuestionDto>> GetQuestionsAsync()
        {
            List<Question> questions = await questionRepository.GetQuestionsAsync();
            return mapper.Map<List<QuestionDto>>(questions);
        }

        public async Task<QuestionDto?> GetQuestionAsync(int id)
        {
            Question question = await questionRepository.GetQuestionAsync(id);
            if (question == null)
                return null;
            return mapper.Map<QuestionDto>(question);
        }

        public async Task<QuestionDto> AddQuestionAsync(QuestionPostDto questionDto)
        {
            Question question = mapper.Map<Question>(questionDto);
            question.CreatedAt = DateTime.Now;
            await questionRepository.AddQuestionAsync(question);
            Question saved = await questionRepository.GetQuestionAsync(question.QuestionId);
            return mapper.Map<QuestionDto>(saved);
        }

        public async Task<bool> UpdateQuestionAsync(int id, QuestionUpdateDto questionDto)
        {
            Question question = await questionRepository.GetQuestionAsync(id);
            if (question == null)
                return false;
            bool answeredNow = question.AnswerText == null && questionDto.AnswerText != null;
            mapper.Map(questionDto, question);
            if (answeredNow)
                question.AnsweredAt = DateTime.Now;
            await questionRepository.UpdateQuestionAsync(question);
            return true;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await questionRepository.DeleteQuestionAsync(id);
        }

        public async Task<List<QuestionDto>> GetQuestionsByUnitAsync(int unitId)
        {
            List<Question> questions = await questionRepository.GetQuestionsByUnitAsync(unitId);
            return mapper.Map<List<QuestionDto>>(questions);
        }

        public async Task<List<QuestionDto>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId)
        {
            List<Question> questions = await questionRepository.GetQuestionsByTeacherSubjectAsync(teacherSubjectId);
            return mapper.Map<List<QuestionDto>>(questions);
        }
    }
}
