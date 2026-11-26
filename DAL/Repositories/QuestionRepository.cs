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

        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .FirstOrDefaultAsync(q => q.QuestionId == id);
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            db.Questions.Add(question);
            await db.SaveChangesAsync();
              return question;
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            db.Questions.Update(question);
            await db.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            Question question = await db.Questions.FirstOrDefaultAsync(q => q.QuestionId == id);
            if (question == null)
                return false;
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Question>> GetQuestionsByUnitAsync(int unitId)
        {
            return await db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .Where(q => q.UnitID == unitId)
                .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByTeacherSubjectAsync(int teacherSubjectId)
        {
            return await db.Questions
                .Include(q => q.Student)
                .Include(q => q.TeacherSubject)
                .Include(q => q.Assignment)
                .Include(q => q.Unit)
                .Where(q => q.TeacherSubjectID == teacherSubjectId)
                .ToListAsync();
        }
    }
}
