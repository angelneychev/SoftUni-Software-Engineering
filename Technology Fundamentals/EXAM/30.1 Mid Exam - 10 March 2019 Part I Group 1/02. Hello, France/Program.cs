using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;

namespace _02._Hello__France
{//изпит
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split("|").ToArray();
            double budget = double.Parse(Console.ReadLine());
            List<string> items = new List<string>();
            List<double> values = new List<double>();
            List<string> command = new List<string>();
            double totalSum = 0;
            double diff = 0;
            foreach (var a in inputLine)
            {
                string[] things = a.Split("->");
                items.Add(things[0]);
                values.Add(double.Parse(things[1]));
            }

            for (int i = 0; i < inputLine.Length; i++)
            {
                double clothes = 0;
                double shoes = 0;
                double accessories = 0;
                if (items[i] == "Clothes")
                {
                    if (values[i] <= 50.00 && budget >= values[i])
                    {
                        budget -= values[i];
                        clothes = values[i] * 1.4;
                        totalSum += clothes;
                        diff += clothes - values[i];
                        command.Add($"{clothes:f2}");
                        //  Console.Write($"{clothes:f2} ");
                    }
                }
                else if (items[i] == "Shoes")
                {
                    if (values[i] <= 35.00 && budget >= values[i])
                    {
                        budget -= values[i];
                        shoes = values[i] * 1.4;
                        diff += shoes - values[i];
                        totalSum += shoes;
                        //  Console.Write($"{shoes:f2} ");
                        command.Add($"{shoes:f2}");
                    }
                }
                else if (items[i] == "Accessories")
                {
                    if (values[i] <= 20.50 && budget >= values[i])
                    {
                        budget -= values[i];
                        accessories = values[i] * 1.4;
                        diff += accessories - values[i];
                        totalSum += accessories;
                        command.Add($"{accessories:f2}");
                        //  Console.Write($"{shoes:f2} ");
                    }
                }
            }

            Console.WriteLine(string.Join(" ", command));
            Console.WriteLine($"Profit: {diff:f2}");
            if ((budget + totalSum) >= 150)
            {
                Console.WriteLine($"Hello, France!");
            }
            else
            {
                Console.WriteLine($"Time to go.");
            }
        }
    }
}
