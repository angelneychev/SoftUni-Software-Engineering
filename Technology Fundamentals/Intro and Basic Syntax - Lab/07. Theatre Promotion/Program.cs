using System;
using System.Runtime.InteropServices;
//Intro and Basic Syntax - Lab
namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            switch (age)
            {
                case int n when (n >= 0 && n <= 18):
                    if (typeOfDay == "Weekday")
                    {
                        price = 12;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        price = 15;
                    }
                    else if (typeOfDay == "Holiday")
                    {
                        price = 5;
                    }
                    break;
                case int n when (n > 18 && n <= 64):
                    if (typeOfDay == "Weekday")
                    {
                        price = 18;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        price = 20;
                    }
                    else if (typeOfDay == "Holiday")
                    {
                        price = 12;
                    }
                    break;
                case int n when (n > 64 && n <= 122):
                    if (typeOfDay == "Weekday")
                    {
                        price = 12;
                    }
                    else if (typeOfDay == "Weekend")
                    {
                        price = 15;
                    }
                    else if (typeOfDay == "Holiday")
                    {
                        price = 10;
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }

            if (price > 0)
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
