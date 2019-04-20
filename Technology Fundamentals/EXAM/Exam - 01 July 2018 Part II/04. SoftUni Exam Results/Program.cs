using System;
using System.Collections.Generic;

namespace _04._SoftUni_Exam_Results
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            var userLanguage = new Dictionary<string, int>();
            var userPoints = new Dictionary<string,int>();
            while (inputLine !="exam finished")
            {
                string[] command = inputLine.Split("-");
                string username = command[0];
                string language = command[1];
                if (!userLanguage.ContainsKey(username) && language != "banned")
                {
                    userLanguage.Add(username,int.Parse(command[1]));
                }
                else
                {
                    
                }






                inputLine = Console.ReadLine();
            }
        }
    }
}
