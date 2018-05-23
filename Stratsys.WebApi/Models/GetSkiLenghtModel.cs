using System.ComponentModel.DataAnnotations;
using Startsys.Core;

namespace Stratsys.WebApi.Models
{
    public class GetSkiLenghtModel
    {
        [Required]
        [Range(ValidationRules.MinHeight,ValidationRules.MaxHeight)]
        public int Height { get; set; }
        
        [Required]
        [Range(ValidationRules.MinAge,ValidationRules.MaxAge)]
        public int Age { get; set; }

        public string SkiType { get; set; }
    }
}