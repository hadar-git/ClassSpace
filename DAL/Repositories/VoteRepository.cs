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

        public List<Vote> GetVotes()
        {
            return db.Votes
                .Include(v => v.Question)
                .Include(v => v.Student)
                .ToList();
        }

        public Vote GetVote(int questionId, int studentId)
        {
            return db.Votes
                .Include(v => v.Question)
                .Include(v => v.Student)
                .FirstOrDefault(v => v.QuestionID == questionId && v.StudentID == studentId);
        }

        public List<Vote> GetVotesByQuestion(int questionId)
        {
            return db.Votes
                .Include(v => v.Student)
                .Where(v => v.QuestionID == questionId)
                .ToList();
        }

        public Vote AddVote(Vote vote)
        {
            db.Votes.Add(vote);
            db.SaveChanges();
            return vote;
        }

        public bool DeleteVote(int questionId, int studentId)
        {
            Vote vote = db.Votes.FirstOrDefault(v => v.QuestionID == questionId && v.StudentID == studentId);
            if (vote == null)
                return false;
            db.Votes.Remove(vote);
            db.SaveChanges();
            return true;
        }
    }
}
