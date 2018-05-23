using System;
using Xunit;

namespace Stratsys.Core.Test
{
    public class UnitTest1
    {
        private SkiService _skiService;

        public UnitTest1()
        {
            _skiService = new SkiService(new Range(0, 125), new Range(30, 245));
        }


        [InlineData(51, 51, 51)]
        [InlineData(78, 78, 78)]
        [InlineData(101, 101, 101)]
        [Theory]
        public void ZeroToFourLenghtSuccess(int personHeight, int min, int max)
        {
            var input = new UserInput
            {
                Age = 3,
                Height = personHeight,
                SkiType = SkiType.Classic
            };

            var res = _skiService.RecomendedSkiLenght(input);

            Assert.Equal(min, res.Min);
            Assert.Equal(max, res.Max);
        }

        [InlineData(110, 120, 130)]
        [InlineData(150, 160, 170)]
        [InlineData(135, 145, 155)]
        [Theory]
        public void FiveToEigthLenghtSuccess(int personHeight, int min, int max)
        {
            var input = new UserInput
            {
                Age = 6,
                Height = personHeight,
                SkiType = SkiType.Classic
            };

            var res = _skiService.RecomendedSkiLenght(input);

            Assert.Equal(min, res.Min);
            Assert.Equal(max, res.Max);
        }

        [InlineData(200, 207, 207)]
        [InlineData(220, 207, 207)]
        [InlineData(160, 180, 180)]
        [InlineData(186, 206, 206)]
        [InlineData(187, 207, 207)]
        [Theory]
        public void AdultClassicSuccess(int personHeight, int min, int max)
        {
            var input = new UserInput
            {
                Age = 25,
                Height = personHeight,
                SkiType = SkiType.Classic
            };

            var res = _skiService.RecomendedSkiLenght(input);

            Assert.Equal(min, res.Min);
            Assert.Equal(max, res.Max);
        }


        [InlineData(200, 210, 215)]
        [InlineData(180, 190, 195)]
        [InlineData(173, 183, 188)]
        [Theory]
        public void AdultFreeStyle(int personHeight, int min, int max)
        {
            var input = new UserInput
            {
                Age = 25,
                Height = personHeight,
                SkiType = SkiType.FreeStyle
            };

            var res = _skiService.RecomendedSkiLenght(input);

            Assert.Equal(min, res.Min);
            Assert.Equal(max, res.Max);
        }


        [InlineData(30)]
        [InlineData(25)]
        [InlineData(0)]
        [InlineData(-175)]
        [InlineData(250)]
        [InlineData(99999)]
        [Theory]
        public void InvalidGeneralLenghtThrowsException(int personHeight)
        {
            Assert.Throws<InvalidHeightException>(() =>
                _skiService.RecomendedSkiLenght(new UserInput {Age = 4, Height = personHeight, SkiType = SkiType.Classic}));
        }

        [InlineData(-1)]
        [InlineData(-175)]
        [InlineData(125)]
        [InlineData(200)]
        [Theory]
        public void InvalidAgeThrowsException(int age)
        {
            Assert.Throws<InvalidAgeException>(() =>
                _skiService.RecomendedSkiLenght(new UserInput {Age = age, Height = 145, SkiType = SkiType.Classic}));
        }
    }

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

    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(int age, int max, int min) : base($"The age {age} must be within the span of {min} - {max}")
        {
        }
    }

    public class InvalidHeightException : Exception
    {
        public InvalidHeightException(int height, int max, int min) : base($"The height {height} must be within the span of {min} - {max}")
        {
        }
    }

    public interface ISkiService
    {
        Range RecomendedSkiLenght(UserInput input);
    }

    public class Range
    {
        public int Min { get; }
        public int Max { get; }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }


    public class UserInput
    {
        public int     Height  { get; set; }
        public int     Age     { get; set; }
        public SkiType SkiType { get; set; }
    }

    public enum SkiType
    {
        Classic,
        FreeStyle
    }
}