using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main()
        {
            string pach = Console.ReadLine();
            int startOfFile = pach.LastIndexOf('\\') + 1;

            string file = pach.Substring(startOfFile);
            int startIndexOfExtention = file.LastIndexOf('.') + 1;
            string nameOfFile = file.Substring(0,startIndexOfExtention-1);
            string exentionOfFile = file.Substring(startIndexOfExtention);

            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {exentionOfFile}");


        }
    }
}
