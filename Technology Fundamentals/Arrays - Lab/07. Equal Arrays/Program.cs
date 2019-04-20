using System;
using System.Linq;
//Arrays - Lab
namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstNumber = 0;
            int secondNumber = 0;
            int sum = 0;

            for (int i = 0; i < first.Length; i++)
            {
                firstNumber = first[i];
                secondNumber = second[i];
                if (firstNumber != secondNumber)
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                else
                {
                    sum += secondNumber;
                }
                if (i == second.Length - 1)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sum}");
                }
            }
        }

    }
}
