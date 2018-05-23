using Startsys.Core.Models;

namespace Startsys.Core.Services.Interfaces
{
    public interface ISkiService
    {
        Range RecomendedSkiLenght(UserInput input);
    }
}