using DAL.Data;

namespace DAL.Repositories
{
    public interface IVoteRepository
    {
        List<Vote> GetVotes();                                // כל הסימונים
        Vote GetVote(int questionId, int studentId);          // סימון אחד
        List<Vote> GetVotesByQuestion(int questionId);        // כל הסימונים של שאלה
        Vote AddVote(Vote vote);                              // הוספה
        bool DeleteVote(int questionId, int studentId);       // מחיקה
    }
}
