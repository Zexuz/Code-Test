using Microsoft.AspNetCore.Mvc;

namespace Stratsys.WebApi.Controllers
{
    [Route("api/v1/[Controller]")]
    public class SkiController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}