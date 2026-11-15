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
        public List<Vote> GetVotes()
        {
            return voteRepository.GetVotes();
        }

        // GET api/Vote/3/7
        [HttpGet("{questionId}/{studentId}")]
        public ActionResult<Vote> GetVote(int questionId, int studentId)
        {
            Vote vote = voteRepository.GetVote(questionId, studentId);
            if (vote == null)
                return NotFound();
            return vote;
        }

        // GET api/Vote/question/3
        [HttpGet("question/{questionId}")]
        public List<Vote> GetVotesByQuestion(int questionId)
        {
            return voteRepository.GetVotesByQuestion(questionId);
        }

        // POST api/Vote
        [HttpPost]
        public Vote AddVote(Vote vote)
        {
            return voteRepository.AddVote(vote);
        }

        // DELETE api/Vote/3/7
        [HttpDelete("{questionId}/{studentId}")]
        public ActionResult DeleteVote(int questionId, int studentId)
        {
            if (!voteRepository.DeleteVote(questionId, studentId))
                return NotFound();
            return Ok();
        }
    }
}
