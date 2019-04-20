using System;
using System.Linq;
//Intro and Basic Syntax - Exercise
namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] divisibleNumbers = new[] { 2, 3, 6, 7, 10 };
            divisibleNumbers.Reverse();
            int numberEnd = 0;

            for (int i = 0; i < divisibleNumbers.Length; i++)
            {
                int divisible = divisibleNumbers[i];
                if (number % divisible == 0)
                {
                    numberEnd = divisible;
                    continue;
                }
            }
            if (numberEnd > 0)
            {
                Console.WriteLine($"The number is divisible by {numberEnd}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }

        }
    }
}
