namespace Telephony.Exceptions
{
    using System;
    class InvalidUrlException:Exception
    {
        private const string ExcMessage = "Invalid URL!";
        public InvalidUrlException()
            :base(ExcMessage)
        {
        }

        public InvalidUrlException(string message) 
            : base(message)
        {
        }
    }
}
