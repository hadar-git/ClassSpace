using DAL.Data;

namespace DAL.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuestionsAsync();                                       // כל השאלות
        Task<Question> GetQuestionAsync(int id);                                        // שאלה לפי קוד
        Task<Question> AddQuestionAsync(Question question);                             // הוספה
        Task<Question> UpdateQuestionAsync(Question question);                          // עדכון
        Task<bool> DeleteQuestionAsync(int id);                                         // מחיקה לפי קוד
        Task<List<Question>> GetQuestionsByUnitAsync(int unitId);                       // השאלות של יחידת לימוד (בשביל האלגוריתם)
        Task<List<Question>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId);   // השאלות שמגיעות למורה במקצוע ובכיתה
    }
}
