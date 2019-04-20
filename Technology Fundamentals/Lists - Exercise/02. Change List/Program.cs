using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//Lists - Exercise
namespace _02._Change_List
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandLine = command.Split();

                if (commandLine[0] == "Delete")
                {
                    numbers.Remove(int.Parse(commandLine[1]));
                }
                else if (commandLine[0] == "Insert")
                {
                    int index = int.Parse(commandLine[2]);
                    int insertValue = int.Parse(commandLine[1]);
                    numbers.Insert(index, insertValue); // Индекса и стойност
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
