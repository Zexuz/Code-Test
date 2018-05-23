using Startsys.Core;
using Startsys.Core.Exceptions;
using Startsys.Core.Models;
using Startsys.Core.Services.Impl;
using Xunit;

namespace Stratsys.Core.Test
{
    public class UnitTest1
    {
        private SkiService _skiService;

        public UnitTest1()
        {
            var ageRange = new Range(Config.MinAge, Config.MaxAge);
            var heightRange = new Range(Config.MinHeight, Config.MaxHeight);

            _skiService = new SkiService(ageRange, heightRange);
        }


        [InlineData(51, 51, 51, 0)]
        [InlineData(78, 78, 78, 1)]
        [InlineData(101, 101, 101, 2)]
        [InlineData(120, 120, 120, 3)]
        [InlineData(128, 128, 128, 4)]
        [InlineData(110, 120, 130, 5)]
        [InlineData(150, 160, 170, 6)]
        [InlineData(135, 145, 155, 7)]
        [InlineData(135, 145, 155, 8)]
        [Theory]
        public void ZeroToFourLenghtSuccess(int personHeight, int min, int max, int age)
        {
            var input = new UserInput
            {
                Age = age,
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

        [InlineData(51, 50, 52, 0)]
        [InlineData(120, 121, 140, 3)]
        [InlineData(128, 100, 127, 4)]
        [InlineData(110, 119, 131, 5)]
        [InlineData(110, 119, 129, 5)]
        [Theory]
        public void ZeroToFourLenghtFails(int personHeight, int min, int max, int age)
        {
            var input = new UserInput
            {
                Age = age,
                Height = personHeight,
                SkiType = SkiType.Classic
            };

            var res = _skiService.RecomendedSkiLenght(input);

            Assert.NotEqual(min, res.Min);
            Assert.NotEqual(max, res.Max);
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
}