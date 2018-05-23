using System;

namespace Startsys.Core.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(int age, int max, int min) : base($"The age {age} must be within the span of {min} - {max}")
        {
        }
    }
}