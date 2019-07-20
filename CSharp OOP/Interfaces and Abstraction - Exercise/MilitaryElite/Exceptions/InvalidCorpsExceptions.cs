namespace MilitaryElite.Exceptions
{
    using  System;
    public class InvalidCorpsExceptions : Exception
    {
        private const string ExcMessage = "Invalid Corps!";
        public InvalidCorpsExceptions()
            :base(ExcMessage)
        {
        }

        public InvalidCorpsExceptions(string message)
            : base(message)
        {
        }
    }
}
