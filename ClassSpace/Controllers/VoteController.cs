using BLL.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private IVoteService voteService;

        public VoteController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        // GET api/Vote
        [HttpGet]
        public async Task<List<VoteDto>> GetVotes()
        {
            return await voteService.GetVotesAsync();
        }

        // GET api/Vote/3/7
        [HttpGet("{questionId}/{studentId}")]
        public async Task<ActionResult<VoteDto>> GetVote(int questionId, int studentId)
        {
            VoteDto? vote = await voteService.GetVoteAsync(questionId, studentId);
            if (vote == null)
                return NotFound();
            return vote;
        }

        // GET api/Vote/question/3
        [HttpGet("question/{questionId}")]
        public async Task<List<VoteDto>> GetVotesByQuestion(int questionId)
        {
            return await voteService.GetVotesByQuestionAsync(questionId);
        }

        // POST api/Vote
        [HttpPost]
        public async Task<ActionResult<VoteDto>> AddVote(VotePostDto voteDto)
        {
            VoteDto? vote = await voteService.AddVoteAsync(voteDto);
            if (vote == null)
                return BadRequest();
            return vote;
        }

        // DELETE api/Vote/3/7
        [HttpDelete("{questionId}/{studentId}")]
        public async Task<ActionResult> DeleteVote(int questionId, int studentId)
        {
            if (!await voteService.DeleteVoteAsync(questionId, studentId))
                return NotFound();
            return Ok();
        }
    }
}
