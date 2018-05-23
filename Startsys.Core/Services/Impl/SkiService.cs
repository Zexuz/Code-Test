using System;
using Startsys.Core.Exceptions;
using Startsys.Core.Models;
using Startsys.Core.Services.Interfaces;

namespace Startsys.Core.Services.Impl
{
    public class SkiService : ISkiService
    {
        private readonly Range _valiAgeRange;
        private readonly Range _validHeightRange;

        public SkiService(Range valiAgeRange, Range validHeightRange)
        {
            _valiAgeRange = valiAgeRange;
            _validHeightRange = validHeightRange;
        }

        public Range RecomendedSkiLenght(UserInput input)
        {
            ValidateInput(input);

            if (input.Age <= 4)
                return new Range(input.Height, input.Height);
            if (input.Age <= 8)
                return new Range(input.Height + 10, input.Height + 20);

            switch (input.SkiType)
            {
                case SkiType.Classic:
                    var maxLenght = 207;
                    var recomendedSkiRange = new Range(20, 20);
                    var recomendedMaxLenght = input.Height + recomendedSkiRange.Max;
                    var recomendedMinLenght = input.Height + recomendedSkiRange.Min;


                    if (recomendedMinLenght > maxLenght && recomendedMaxLenght > maxLenght)
                        return new Range(maxLenght, maxLenght);

                    return new Range(recomendedMinLenght, recomendedMaxLenght);
                case SkiType.FreeStyle:
                    var recomendedSkiRangeFree = new Range(10, 15);
                    var recomendedMaxLenghtFree = input.Height + recomendedSkiRangeFree.Max;
                    var recomendedMinLenghtFree = input.Height + recomendedSkiRangeFree.Min;

                    return new Range(recomendedMinLenghtFree, recomendedMaxLenghtFree);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ValidateInput(UserInput input)
        {
            if (input.Height <= _validHeightRange.Min)
                throw new InvalidHeightException(input.Height, _validHeightRange.Min, _validHeightRange.Max);

            if (input.Height >= _validHeightRange.Max)
                throw new InvalidHeightException(input.Height, _validHeightRange.Min, _validHeightRange.Max);

            if (input.Age <= _valiAgeRange.Min)
                throw new InvalidAgeException(input.Age, _valiAgeRange.Min, _valiAgeRange.Max);

            if (input.Age >= _valiAgeRange.Max)
                throw new InvalidAgeException(input.Age, _valiAgeRange.Min, _valiAgeRange.Max);
        }
    }
}