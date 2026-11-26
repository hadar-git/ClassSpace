using DAL.Data;
using DAL.Repositories;

namespace BLL.Services
{
    public class VoteService : IVoteService
    {
        private IVoteRepository voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public async Task<List<Vote>> GetVotesAsync()
        {
            return await voteRepository.GetVotesAsync();
        }

        public async Task<Vote> GetVoteAsync(int questionId, int studentId)
        {
            return await voteRepository.GetVoteAsync(questionId, studentId);
        }

        public async Task<List<Vote>> GetVotesByQuestionAsync(int questionId)
        {
            return await voteRepository.GetVotesByQuestionAsync(questionId);
        }

        public async Task<Vote> AddVoteAsync(Vote vote)
        {
            return await voteRepository.AddVoteAsync(vote);
        }

        public async Task<bool> DeleteVoteAsync(int questionId, int studentId)
        {
            return await voteRepository.DeleteVoteAsync(questionId, studentId);
        }
    }
}
