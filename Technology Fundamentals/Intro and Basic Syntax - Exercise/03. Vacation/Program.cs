using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//Intro and Basic Syntax - Exercise
namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCoun = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double[] studentsPriceDay = { 8.45, 9.80, 10.46 };
            double[] businessPriceDay = { 10.90, 15.60, 16 };
            double[] regularPriceDay = { 15, 20, 22.50 };
            double sum = -1;

            switch (groupType)
            {
                //case int n when (n >= 0 && n <= 18):
                case "Students":
                    if (day == "Friday")
                    {
                        sum = studentsPriceDay[0] * peopleCoun;
                    }
                    else if (day == "Saturday")
                    {
                        sum = studentsPriceDay[1] * peopleCoun;
                    }
                    else if (day == "Sunday")
                    {
                        sum = studentsPriceDay[2] * peopleCoun;
                    }
                    if (peopleCoun >= 30 && peopleCoun < 100)
                    {
                        sum = sum - ((sum * 15) / 100);
                    }
                    break;
                case "Business":
                    if (peopleCoun >= 100)
                    {
                        peopleCoun -= 10;
                    }
                    if (day == "Friday")
                    {
                        sum = businessPriceDay[0] * peopleCoun;
                    }
                    else if (day == "Saturday")
                    {
                        sum = businessPriceDay[1] * peopleCoun;

                    }
                    else if (day == "Sunday")
                    {
                        sum = businessPriceDay[2] * peopleCoun;
                    }

                    break;
                case "Regular":
                    if (day == "Friday")
                    {
                        sum = regularPriceDay[0] * peopleCoun;
                    }
                    else if (day == "Saturday")
                    {
                        sum = regularPriceDay[1] * peopleCoun;
                    }
                    else if (day == "Sunday")
                    {
                        sum = regularPriceDay[2] * peopleCoun;
                    }
                    if (peopleCoun >= 10 && peopleCoun <= 20)
                    {
                        sum = sum - ((sum * 5) / 100);
                    }
                    break;
            }

            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
