using DAL.Data;

namespace BLL.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(int id);
        Task<Question> AddQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(int id);
        Task<List<Question>> GetQuestionsByUnitAsync(int unitId);
        Task<List<Question>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId);
    }
}
