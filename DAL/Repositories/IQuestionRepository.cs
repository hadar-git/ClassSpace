using DAL.Data;

namespace DAL.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestions();                                       // כל השאלות
        Question GetQuestion(int id);                                        // שאלה לפי קוד
        Question AddQuestion(Question question);                             // הוספה
        Question UpdateQuestion(Question question);                          // עדכון
        bool DeleteQuestion(int id);                                         // מחיקה לפי קוד
        List<Question> GetQuestionsByUnit(int unitId);                       // השאלות של יחידת לימוד (בשביל האלגוריתם)
        List<Question> GetQuestionsByTeacherSubject(int teacherSubjectId);   // השאלות שמגיעות למורה במקצוע ובכיתה
    }
}
