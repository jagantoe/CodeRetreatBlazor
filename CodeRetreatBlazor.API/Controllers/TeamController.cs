using CodeRetreatBlazor.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ChallengeContext _challengeContext;

        public TeamController(ChallengeContext challengeContext)
        {
            _challengeContext = challengeContext;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string name, string password)
        {
            var team = await _challengeContext.Teams.FirstOrDefaultAsync(t => t.Name == name);
            if (team.Name == name && team.Password == password)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
