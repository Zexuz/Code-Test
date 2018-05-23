using System;
using Xunit;
using Xunit.Abstractions;

namespace Stratsys.Core.Test
{
    public class UnitTest1
    {
        private SkiService _skiService;

        public UnitTest1()
        {
            _skiService = new SkiService();
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
            Assert.False(true);
        }
    }

    public class SkiService : ISkiService
    {
        public SkiRange RecomendedSkiLenght(UserInput input)
        {
            if (input.Age <= 4)
                return new SkiRange(input.Height, input.Height);
            if (input.Age <= 8)
                return new SkiRange(input.Height + 10, input.Height + 20);

            switch (input.SkiType)
            {
                case SkiType.Classic:
                    var maxLenght = 207;
                    var recomendedSkiRange = new SkiRange(20, 20);
                    var recomendedMaxLenght = input.Height + recomendedSkiRange.Max;
                    var recomendedMinLenght = input.Height + recomendedSkiRange.Min;


                    if (recomendedMinLenght > maxLenght && recomendedMaxLenght > maxLenght)
                        return new SkiRange(maxLenght, maxLenght);

                    return new SkiRange(recomendedMinLenght, recomendedMaxLenght);
                case SkiType.FreeStyle:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            throw new System.NotImplementedException();
        }
    }

    public interface ISkiService
    {
        SkiRange RecomendedSkiLenght(UserInput input);
    }

    public class SkiRange
    {
        public int Min { get; }
        public int Max { get; }

        public SkiRange(int min, int max)
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