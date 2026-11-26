using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private ClassSpaceDB db;

        public VoteRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<Vote>> GetVotesAsync()
        {
            return await db.Votes
                .Include(v => v.Question)
                .Include(v => v.Student)
                .ToListAsync();
        }

        public async Task<Vote> GetVoteAsync(int questionId, int studentId)
        {
            return await db.Votes
                .Include(v => v.Question)
                .Include(v => v.Student)
                .FirstOrDefaultAsync(v => v.QuestionID == questionId && v.StudentID == studentId);
        }

        public async Task<List<Vote>> GetVotesByQuestionAsync(int questionId)
        {
            return await db.Votes
                .Include(v => v.Student)
                .Where(v => v.QuestionID == questionId)
                .ToListAsync();
        }

        public async Task<Vote> AddVoteAsync(Vote vote)
        {
            db.Votes.Add(vote);
            await db.SaveChangesAsync();
            return vote;
        }

        public async Task<bool> DeleteVoteAsync(int questionId, int studentId)
        {
            Vote vote = await db.Votes.FirstOrDefaultAsync(v => v.QuestionID == questionId && v.StudentID == studentId);
            if (vote == null)
                return false;
            db.Votes.Remove(vote);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
