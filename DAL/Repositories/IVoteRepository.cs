using DAL.Data;

namespace DAL.Repositories
{
    public interface IVoteRepository
    {
        Task<List<Vote>> GetVotesAsync();                                // כל הסימונים
        Task<Vote> GetVoteAsync(int questionId, int studentId);          // סימון אחד
        Task<List<Vote>> GetVotesByQuestionAsync(int questionId);        // כל הסימונים של שאלה
        Task<Vote> AddVoteAsync(Vote vote);                              // הוספה
        Task<bool> DeleteVoteAsync(int questionId, int studentId);       // מחיקה
    }
}
