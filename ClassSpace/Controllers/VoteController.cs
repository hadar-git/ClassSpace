using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private IVoteRepository voteRepository;

        public VoteController(IVoteRepository voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        // GET api/Vote
        [HttpGet]
        public async Task<List<Vote>> GetVotes()
        {
            return await voteRepository.GetVotesAsync();
        }

        // GET api/Vote/3/7
        [HttpGet("{questionId}/{studentId}")]
        public async Task<ActionResult<Vote>> GetVote(int questionId, int studentId)
        {
            Vote vote = await voteRepository.GetVoteAsync(questionId, studentId);
            if (vote == null)
                return NotFound();
            return vote;
        }

        // GET api/Vote/question/3
        [HttpGet("question/{questionId}")]
        public async Task<List<Vote>> GetVotesByQuestion(int questionId)
        {
            return await voteRepository.GetVotesByQuestionAsync(questionId);
        }

        // POST api/Vote
        [HttpPost]
        public async Task<Vote> AddVote(Vote vote)
        {
            return await voteRepository.AddVoteAsync(vote);
        }

        // DELETE api/Vote/3/7
        [HttpDelete("{questionId}/{studentId}")]
        public async Task<ActionResult> DeleteVote(int questionId, int studentId)
        {
            if (!await voteRepository.DeleteVoteAsync(questionId, studentId))
                return NotFound();
            return Ok();
        }
    }
}
