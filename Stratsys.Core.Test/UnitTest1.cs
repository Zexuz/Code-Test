using Xunit;

namespace Stratsys.Core.Test
{
    public class UnitTest1
    {
        [InlineData(51, 51, 51)]
        [InlineData(78, 78, 78)]
        [InlineData(101, 101, 101)]
        [Theory]
        public void ZeroToFourLenghtSuccess(int personHeight, int min, int max)
        {
            Assert.False(true);
        }

        [InlineData(110, 110, 120)]
        [InlineData(150, 160, 170)]
        [InlineData(135, 145, 155)]
        [Theory]
        public void FiveToEigthLenghtSuccess(int personHeight, int min, int max)
        {
            Assert.False(true);
        }

        [InlineData(200, 207, 207)]
        [InlineData(220, 207, 207)]
        [InlineData(160, 180, 180)]
        [InlineData(186, 206, 206)]
        [InlineData(187, 207, 207)]
        [Theory]
        public void AdultClassicSuccess(int personHeight, int min, int max)
        {
            Assert.False(true);
        }


        [InlineData(200, 210, 215)]
        [InlineData(180, 190, 195)]
        [InlineData(173, 183, 188)]
        [Theory]
        public void AdultFreeStyle(int personHeight, int min, int max)
        {
            Assert.False(true);
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
            throw new System.NotImplementedException();
        }
    }

    public interface ISkiService
    {
        SkiRange RecomendedSkiLenght(UserInput input);
    }

    public class SkiRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
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