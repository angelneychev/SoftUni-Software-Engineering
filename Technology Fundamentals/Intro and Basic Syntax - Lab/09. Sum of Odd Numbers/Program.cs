using System;
//Intro and Basic Syntax - Lab
namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumberOdd = int.Parse(Console.ReadLine());
            int number = 1;
            int sum = 0;
            int count = 0;

            for (int i = 1; i <= int.MaxValue; i += 2)
            {
                count++;

                if (count > countNumberOdd)
                {
                    break;
                }
                sum += i;
                Console.WriteLine($"{i}");

            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
