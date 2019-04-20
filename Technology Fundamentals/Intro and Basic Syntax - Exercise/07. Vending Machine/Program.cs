using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
//Intro and Basic Syntax - Exercise
namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            //0.1, 0.2, 0.5, 1, and 2 
            string input = Console.ReadLine();

            double sum = 0;

            while (input != "Start")
            {
                // double money = double.Parse(Console.ReadLine());
                switch (input)
                {
                    case "0.1":
                        sum += 0.1;
                        break;
                    case "0.2":
                        sum += 0.2;
                        break;
                    case "0.5":
                        sum += 0.5;
                        break;
                    case "1":
                        sum += 1;
                        break;
                    case "2":
                        sum += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {input}");
                        break;
                }
                input = Console.ReadLine();
                if (input == "Start")
                {
                    input = Console.ReadLine();
                    break;
                }
            }
            //“Nuts”, “Water”, “Crisps”, “Soda”, “Coke”. The prices are: 2.0, 0.7, 1.5, 0.8, 1.0 
            double priceProducts = 0;
            double total = 0;
            bool a = true;
            while (input != "End")
            {

                switch (input)
                {
                    case "Nuts":
                        priceProducts = 2.0;
                        break;
                    case "Water":
                        priceProducts = 0.7;
                        break;
                    case "Crisps":
                        priceProducts = 1.5;
                        break;
                    case "Soda":
                        priceProducts = 0.8;
                        break;
                    case "Coke":
                        priceProducts = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                total += priceProducts;
                if (sum - total >= 0 && priceProducts > 0)
                {
                    priceProducts += priceProducts;
                    Console.WriteLine($"Purchased {input.ToLower()}");
                }
                else
                {
                    total -= priceProducts;
                    if (priceProducts > 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
            }
            Console.WriteLine($"Change: {(sum - total):f2}");
        }
    }
}
