using DAL.Data;

namespace BLL.Services
{
    public interface IVoteService
    {
        Task<List<Vote>> GetVotesAsync();
        Task<Vote> GetVoteAsync(int questionId, int studentId);
        Task<List<Vote>> GetVotesByQuestionAsync(int questionId);
        Task<Vote> AddVoteAsync(Vote vote);
        Task<bool> DeleteVoteAsync(int questionId, int studentId);
    }
}
