using System;
using Microsoft.AspNetCore.Mvc;
using Startsys.Core.Models;
using Startsys.Core.Services.Interfaces;
using Stratsys.WebApi.Models;

namespace Stratsys.WebApi.Controllers.V1
{
    [Route("api/v1/[Controller]")]
    public class SkiController : Controller
    {
        private readonly ISkiService _skiService;

        public SkiController(ISkiService skiService)
        {
            _skiService = skiService;
        }

        [HttpPost("recomended")]
        public IActionResult Index([FromBody] UserBodyInfoModel model)
        {
            var skiType = SkiType.None;
            if (!string.IsNullOrEmpty(model.SkiType) && !Enum.TryParse(model.SkiType, true, out skiType))
            {
                return BadRequest("Not a valid ski type.");
            }
            
            var userInput = new UserInput
            {
                Age = model.Age,
                Height = model.Height,
                SkiType = skiType
            };

            var recomendednRange = _skiService.RecomendedSkiLenght(userInput);
            return Ok(recomendednRange);
        }
    }
}