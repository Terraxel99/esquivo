namespace Esquivo.Exceptions
{
    using System;

    public class InvalidObstacleSpacingException : Exception
    {
        public InvalidObstacleSpacingException(string message) : base(message) { }
    }
}