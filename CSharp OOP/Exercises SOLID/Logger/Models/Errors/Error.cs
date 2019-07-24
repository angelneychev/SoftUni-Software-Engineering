using System;
using Logger.Models.Enumerations;
using Logger.Models.Contracts;
namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; }
        public string Message { get; }
        public Level Level { get; }
    }
}
