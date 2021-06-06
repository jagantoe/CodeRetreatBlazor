using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
