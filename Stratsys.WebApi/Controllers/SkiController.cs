using Microsoft.AspNetCore.Mvc;

namespace Stratsys.WebApi.Controllers
{
    [Route("api/v1/[Controller]")]
    public class SkiController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("Hello wordfl!");
        }
    }
}