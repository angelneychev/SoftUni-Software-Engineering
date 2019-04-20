using System;
//Programming Fundamentals - Mid Exam - 4 November 2018
namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int sum = day * 50;
            for (int i = 1; i <= day; i++)
            {
                if (i % 10 == 0)
                {
                    countPeople -= 2;
                }
                if (i % 15 == 0)
                {
                    countPeople += 5;
                }
                if (i % 3 == 0)
                {
                    sum -= 3 * countPeople;
                }
                if (i % 5 == 0)
                {
                    sum += 20 * countPeople;
                    if (i % 3 == 0)
                    {
                        sum -= 2 * countPeople;
                    }
                }
                sum -= 2 * countPeople;
            }
            int coins = sum / countPeople;
            Console.WriteLine($"{countPeople} companions received {coins} coins each.");
        }
    }
}
