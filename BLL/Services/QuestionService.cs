using DAL.Data;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await questionRepository.GetQuestionsAsync();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await questionRepository.GetQuestionAsync(id);
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            return await questionRepository.AddQuestionAsync(question);
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            return await questionRepository.UpdateQuestionAsync(question);
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await questionRepository.DeleteQuestionAsync(id);
        }

        public async Task<List<Question>> GetQuestionsByUnitAsync(int unitId)
        {
            return await questionRepository.GetQuestionsByUnitAsync(unitId);
        }

        public async Task<List<Question>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId)
        {
            return await questionRepository.GetQuestionsByTeacherSubjectAsync(teacherSubjectId);
        }
    }
}

