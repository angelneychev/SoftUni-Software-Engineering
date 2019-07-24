using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatExcaption : Exception
    {
        private const string ExcMesseg =
            "Invalid DateTime Format!";
        public InvalidDateFormatExcaption()
            :base(ExcMesseg)
        {
        }

        public InvalidDateFormatExcaption(string message)
            : base(message)
        {
        }

        public InvalidDateFormatExcaption(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
