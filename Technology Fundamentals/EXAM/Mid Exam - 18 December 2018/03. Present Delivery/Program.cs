using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Mid Exam - 18 December 2018
namespace _03._Present_Delivery
{
    class Program
    {
        static void Main()
        {

            List<int> houseMembers = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();
            string commandLine = Console.ReadLine();

            while (commandLine == "Merry Xmas!")
            {
                string[] command = commandLine.Split();

                for (int i = 0; i < houseMembers.Count; i++)
                {

                }


                commandLine = Console.ReadLine();
            }

        }
    }
}
