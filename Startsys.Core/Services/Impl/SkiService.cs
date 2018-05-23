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
                return GetSkiLenghtForSmallKids(input);
            if (input.Age <= 8)
                return GetSkiLenghtForMediumKids(input);

            switch (input.SkiType)
            {
                case SkiType.Classic:   return GetSkiLengthForClassic(input);
                case SkiType.FreeStyle: return GetSkiLenghtForFeeStyle(input);
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

        private static Range GetSkiLenghtForSmallKids(UserInput input)
        {
            var recomendedSkiRange = new Range(0, 0);
            return CalculateRange(input.Height, recomendedSkiRange);
        }

        private static Range GetSkiLenghtForMediumKids(UserInput input)
        {
            var recomendedSkiRange = new Range(10, 20);
            return CalculateRange(input.Height, recomendedSkiRange);
        }

        private static Range GetSkiLengthForClassic(UserInput input)
        {
            var maxLenght = 207;
            var recomendedSkiRange = new Range(20, 20);

            var recomendedLenght = CalculateRange(input.Height, recomendedSkiRange);

            if (recomendedLenght.Min > maxLenght && recomendedLenght.Max > maxLenght)
                return new Range(maxLenght, maxLenght);

            if (recomendedLenght.Max > maxLenght)
                return new Range(recomendedLenght.Min, maxLenght);

            return recomendedLenght;
        }

        private static Range GetSkiLenghtForFeeStyle(UserInput input)
        {
            var recomendedSkiRange = new Range(10, 15);
            return CalculateRange(input.Height, recomendedSkiRange);
        }


        private static Range CalculateRange(int constant, Range range)
        {
            return new Range(constant + range.Min, constant + range.Max);
        }
    }
}