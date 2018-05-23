using System;

namespace Startsys.Core.Exceptions
{
    public class InvalidHeightException : Exception
    {
        public InvalidHeightException(int height, int max, int min) : base($"The height {height} must be within the span of {min} - {max}")
        {
        }
    }
}