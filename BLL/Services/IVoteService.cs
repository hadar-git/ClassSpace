using DTO;

namespace BLL.Services
{
    public interface IVoteService
    {
        Task<List<VoteDto>> GetVotesAsync();
        Task<VoteDto?> GetVoteAsync(int questionId, int studentId);
        Task<List<VoteDto>> GetVotesByQuestionAsync(int questionId);
        Task<VoteDto?> AddVoteAsync(VotePostDto voteDto);
        Task<bool> DeleteVoteAsync(int questionId, int studentId);
    }
}
