using System;
using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {

        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public IOManager(string currentDirectory, string currentFile)
            :this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPach => this.currentPath + this.currentDirectory;

        public string CurrentFilePach => this.CurrentDirectoryPach + this.currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPach))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPach);
            }
            File.WriteAllText(this.CurrentFilePach, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
