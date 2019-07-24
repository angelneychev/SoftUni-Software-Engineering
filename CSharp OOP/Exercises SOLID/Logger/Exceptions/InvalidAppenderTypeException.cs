using System;

namespace Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string ExcMesseg =
            "Invalid Appder Type!";

        public InvalidAppenderTypeException()
            :base(ExcMesseg)
        {
        }

        public InvalidAppenderTypeException(string message) : base(message)
        {
        }
    }
}
