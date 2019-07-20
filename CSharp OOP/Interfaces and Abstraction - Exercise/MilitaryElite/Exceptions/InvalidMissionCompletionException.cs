namespace MilitaryElite.Exceptions
{
    using System;
    public class InvalidMissionCompletionException : Exception
    {
        private const string ExcMessage = "You cannot finish alreydy completed mission!";
        public InvalidMissionCompletionException()
        :base(ExcMessage)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }
    }
}
