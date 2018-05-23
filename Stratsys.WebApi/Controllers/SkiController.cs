using System;
using Microsoft.AspNetCore.Mvc;
using Startsys.Core.Models;
using Startsys.Core.Services.Interfaces;
using Stratsys.WebApi.Models;

namespace Stratsys.WebApi.Controllers
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
        public IActionResult Index([FromBody] GetSkiLenghtModel recomendenModel)
        {
            var skiType = SkiType.None;
            if (!string.IsNullOrEmpty(recomendenModel.SkiType) && !Enum.TryParse(recomendenModel.SkiType, true, out skiType))
            {
                return BadRequest("Not a valid ski type.");
            }
            
            var userInput = new UserInput
            {
                Age = recomendenModel.Age,
                Height = recomendenModel.Height,
                SkiType = skiType
            };

            var recomendednRange = _skiService.RecomendedSkiLenght(userInput);
            return Ok(recomendednRange);
        }
    }
}