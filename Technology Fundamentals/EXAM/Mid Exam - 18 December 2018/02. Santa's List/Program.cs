using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Mid Exam - 18 December 2018

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main()
        {
            List<string> initialList = Console.ReadLine()
                .Split("&")
                .ToList();
            string commandLine = Console.ReadLine();

            while (commandLine != "Finished!")
            {
                string[] command = commandLine.Split();

                if (command[0] == "Bad")
                {
                    if (!initialList.Contains(command[1]))
                    {
                        initialList.Insert(0, command[1]);
                    }
                }
                else if (command[0] == "Good")
                {
                    if (initialList.Contains(command[1]))
                    {
                        initialList.Remove(command[1]);
                    }
                }
                else if (command[0] == "Rename")
                {
                    if (initialList.Contains(command[1]))
                    {
                        int index = initialList.IndexOf(command[1]);
                        // initialList.RemoveAt(index);
                        initialList[index] = command[2];
                    }
                }
                else if (command[0] == "Rearrange")
                {
                    if (initialList.Contains(command[1]))
                    {
                        int index = initialList.IndexOf(command[1]);
                        initialList.Add(command[1]);
                        initialList.RemoveAt(index);
                    }
                }
                commandLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", initialList));
        }
    }
}
