using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string dateFotrmat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private string currentFile = "\\logs.txt";

        private string currentPath;

        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory,currentFile);

            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set; }

        public ulong Size => GetFileSize();
        
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                dateTime.ToString(dateFotrmat, CultureInfo.InvariantCulture),
                level.ToString(), message);

            return formattedMessage;
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text.ToCharArray().Where(c => Char.IsLetter(c)).Sum(c => (int) c);

            return size;
        }
    }
}
