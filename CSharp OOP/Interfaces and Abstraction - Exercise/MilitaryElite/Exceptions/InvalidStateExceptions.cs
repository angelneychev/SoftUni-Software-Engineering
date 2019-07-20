namespace MilitaryElite.Exceptions
{
    using System;
    public class InvalidStateExceptions : Exception
    {
        private const string ExcMessage = "Invalid mission state!";
        public InvalidStateExceptions()
            :base(ExcMessage)
        {
        }

        public InvalidStateExceptions(string message) : base(message)
        {
        }
    }
}
