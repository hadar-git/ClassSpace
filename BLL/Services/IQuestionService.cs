using DTO;

namespace BLL.Services
{
    public interface IQuestionService
    {
        Task<List<QuestionDto>> GetQuestionsAsync();
        Task<QuestionDto?> GetQuestionAsync(int id);
        Task<QuestionDto> AddQuestionAsync(QuestionPostDto questionDto);
        Task<bool> UpdateQuestionAsync(int id, QuestionUpdateDto questionDto);
        Task<bool> DeleteQuestionAsync(int id);
        Task<List<QuestionDto>> GetQuestionsByUnitAsync(int unitId);
        Task<List<QuestionDto>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId);
    }
}
