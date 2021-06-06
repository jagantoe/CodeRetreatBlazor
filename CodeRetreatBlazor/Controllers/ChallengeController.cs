using Microsoft.AspNetCore.Mvc;

namespace CodeRetreatBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengeController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetChallengeById(int id)
        {
            return View();
        }
    }
}
