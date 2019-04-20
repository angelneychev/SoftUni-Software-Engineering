using System;
using System.ComponentModel;
//Intro and Basic Syntax - More Exercise
namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            double totalSum = sum;
            double price = 0;
            while (true)
            {
                string gameName = Console.ReadLine();
                if (gameName == "Game Time")
                {
                    break;
                }
                switch (gameName)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                totalSum -= price;
                if (totalSum == 0)
                {
                    Console.WriteLine("Out of money!");
                }
                else if (totalSum < 0)
                {
                    Console.WriteLine("Too Expensive");
                    totalSum = totalSum + price;
                    // break;
                }
                else if (totalSum > 0 && price > 0)
                {
                    Console.WriteLine($"Bought {gameName}");
                }
            }
            Console.WriteLine($"Total spent: ${(sum - totalSum):f2}. " +
                              $"Remaining: ${(totalSum):f2}");
        }
    }
}
