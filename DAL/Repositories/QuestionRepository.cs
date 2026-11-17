using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private ClassSpaceDB db;

        public QuestionRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<Question> GetQuestions()
        {
            return db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .ToList();
        }

        public Question GetQuestion(int id)
        {
            return db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .FirstOrDefault(q => q.QuestionId == id);
        }

        public Question AddQuestion(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return question;
        }

        public Question UpdateQuestion(Question question)
        {
            db.Questions.Update(question);
            db.SaveChanges();
            return question;
        }

        public bool DeleteQuestion(int id)
        {
            Question question = db.Questions.FirstOrDefault(q => q.QuestionId == id);
            if (question == null)
                return false;
            db.Questions.Remove(question);
            db.SaveChanges();
            return true;
        }

        public List<Question> GetQuestionsByUnit(int unitId)
        {
            return db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .Where(q => q.UnitID == unitId)
                .ToList();
        }

        public List<Question> GetQuestionsByTeacherSubject(int teacherSubjectId)
        {
            return db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .Where(q => q.TeacherSubjectID == teacherSubjectId)
                .ToList();
        }
    }
}
