using System;
using System.Globalization;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsolAppender : IAppender
    {
        private const string dateFotrmat = "M/dd/yyyy h:mm:ss tt";
        private int messagesAppended;

        private ConsolAppender()
        {
            this.messagesAppended = 0;
        }

        public ConsolAppender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format,
                dateTime.ToString(dateFotrmat, CultureInfo.InvariantCulture), level.ToString(), message);
            Console.WriteLine(formattedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
