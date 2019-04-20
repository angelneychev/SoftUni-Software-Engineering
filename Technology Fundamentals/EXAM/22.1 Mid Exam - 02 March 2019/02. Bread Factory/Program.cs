using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
//Programming Fundamentals - Мid Exam - 02 March 2019
namespace _02._Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
                .Split("|")
                .ToList();
            int energy = 100;
            int coins = 100;
            bool temp1 = true;
            //rest-2|order-10|eggs-100|rest-10 
            for (int i = 0; i < inputLine.Count; i++)
            {
                string[] command = inputLine[i].Split("-");
                switch (command[0])
                {
                    case "rest":
                        energy += int.Parse(command[1]);
                        if (energy > 100)
                        {
                            energy -= int.Parse(command[1]);
                            int diff = 100 - energy;
                            energy += diff;
                            Console.WriteLine($"You gained {diff} energy.");
                        }
                        else if (energy <= 100)
                        {
                            Console.WriteLine($"You gained {int.Parse(command[1])} energy.");
                        }
                        Console.WriteLine($"Current energy: {energy}.");
                        break;
                    case "order":
                        energy -= 30;
                        if (energy >= 0)
                        {
                            coins += int.Parse(command[1]);
                            Console.WriteLine($"You earned {double.Parse(command[1])} coins.");
                        }
                        else
                        {
                            energy += 80;
                            Console.WriteLine("You had to rest!");
                        }
                        break;
                    default:
                        coins -= int.Parse(command[1]);
                        if (coins <= 0)
                        {
                            Console.WriteLine($"Closed! Cannot afford {command[0]}.");
                            temp1 = false;
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"You bought {command[0]}.");
                            // temp1 = false;
                        }
                        break;
                }

            }

            if (!temp1) return;
            Console.WriteLine($"Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");

        }
    }
}
