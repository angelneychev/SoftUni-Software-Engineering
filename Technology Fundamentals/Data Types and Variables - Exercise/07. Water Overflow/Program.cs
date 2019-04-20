using System;
using System.Diagnostics.CodeAnalysis;
// Data Types and Variables - Exercise
namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int totalLitersWaters = 0;
            int count = 0;

            for (int i = 0; i < input; i++)
            {
                int litersWater = int.Parse(Console.ReadLine());
                if (totalLitersWaters + litersWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalLitersWaters += litersWater;
                }
            }
            Console.WriteLine(totalLitersWaters);
        }
    }
}
