using AutoMapper;
using DAL.Data;
using DAL.Repositories;
using DTO;

namespace BLL.Services
{
    public class VoteService : IVoteService
    {
        private IVoteRepository voteRepository;
        private IMapper mapper;

        public VoteService(IVoteRepository voteRepository, IMapper mapper)
        {
            this.voteRepository = voteRepository;
            this.mapper = mapper;
        }

        public async Task<List<VoteDto>> GetVotesAsync()
        {
            List<Vote> votes = await voteRepository.GetVotesAsync();
            return mapper.Map<List<VoteDto>>(votes);
        }

        public async Task<VoteDto?> GetVoteAsync(int questionId, int studentId)
        {
            Vote vote = await voteRepository.GetVoteAsync(questionId, studentId);
            if (vote == null)
                return null;
            return mapper.Map<VoteDto>(vote);
        }

        public async Task<List<VoteDto>> GetVotesByQuestionAsync(int questionId)
        {
            List<Vote> votes = await voteRepository.GetVotesByQuestionAsync(questionId);
            return mapper.Map<List<VoteDto>>(votes);
        }

        public async Task<VoteDto?> AddVoteAsync(VotePostDto voteDto)
        {
            Vote existing = await voteRepository.GetVoteAsync(voteDto.QuestionID, voteDto.StudentID);
            if (existing != null)
                return null;
            Vote vote = mapper.Map<Vote>(voteDto);
            await voteRepository.AddVoteAsync(vote);
            Vote saved = await voteRepository.GetVoteAsync(vote.QuestionID, vote.StudentID);
            return mapper.Map<VoteDto>(saved);
        }

        public async Task<bool> DeleteVoteAsync(int questionId, int studentId)
        {
            return await voteRepository.DeleteVoteAsync(questionId, studentId);
        }
    }
}
