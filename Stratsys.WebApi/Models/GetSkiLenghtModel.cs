using System.ComponentModel.DataAnnotations;
using Startsys.Core;

namespace Stratsys.WebApi.Models
{
    public class GetSkiLenghtModel
    {
        [Required]
        [Range(Config.MinHeight,Config.MaxHeight)]
        public int Height { get; set; }
        
        [Required]
        [Range(Config.MinAge,Config.MaxAge)]
        public int Age { get; set; }

        public string SkiType { get; set; }
    }
}