using System;
using System.Globalization;
using System.IO;
using Logger.Exceptions;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Errors;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string dateFotrmat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);
            if (!hasParsed)
            {
                throw new  InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFotrmat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatExcaption();
            }

            return new Error(dateTime,message,level);
        }
    }
}
