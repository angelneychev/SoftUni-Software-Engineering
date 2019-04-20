using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Retake Exam - 28 October 2018 Part I
namespace _01._Google_Searches
{
    class Program
    {
        static void Main()
        {
            int totalDays = int.Parse(Console.ReadLine());
            int numberOfUser = int.Parse(Console.ReadLine());
            double moneyPerSearch = double.Parse(Console.ReadLine());

            double totalMoney = 0;

            for (int i = 1; i <= numberOfUser; i++)
            {
                double sum = 0;
                int wordInRange = int.Parse(Console.ReadLine());
                if (wordInRange == 1)
                {
                    sum = (moneyPerSearch * 2) * totalDays;
                }
                if (wordInRange > 1 && wordInRange <= 5)
                {
                    sum = moneyPerSearch * totalDays;
                }
                if (i % 3 == 0 && wordInRange <= 5)
                {
                    sum *= 3;
                }
                totalMoney += sum;
            }
            Console.WriteLine($"Total money earned for {totalDays} days: {totalMoney:f2}");
        }
    }
}
