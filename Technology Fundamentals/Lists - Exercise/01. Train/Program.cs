using System;
using System.Collections.Generic;
using System.Linq;
//Lists - Exercise
namespace _01._Train_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagon = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            //List<int> wagon = new List<int>()
            //{
            //    32, 54, 21, 12, 4, 0, 23
            //};
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandLine = command.Split();

                if (commandLine[0] == "Add")
                {
                    wagon.Add(int.Parse(commandLine[1]));
                }
                else if (commandLine[0] != "Add" && commandLine[0] != "end")
                {
                    for (int i = 0; i < wagon.Count; i++)
                    {
                        int addPassengers = int.Parse(commandLine[0]);//Добавяме пасажери
                        int currenPassengersWagon = wagon[i]; // Взимаме настоящата бройка пасажери
                        if ((currenPassengersWagon + addPassengers) <= capacity)
                        {
                            wagon[i] += addPassengers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagon));
        }
    }
}
