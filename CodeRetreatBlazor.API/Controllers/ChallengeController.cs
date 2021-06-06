using CodeRetreatBlazor.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengeController : ControllerBase
    {
        private readonly ChallengeContext _challengeContext;

        public ChallengeController(ChallengeContext challengeContext)
        {
            _challengeContext = challengeContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChallengeById(int id)
        {
            var challenge = await _challengeContext.Challenges.SingleOrDefaultAsync(c => c.Id == id);
            if (challenge == null)
            {
                return NotFound();
            }
            return Ok(challenge);
        }
    }
}
