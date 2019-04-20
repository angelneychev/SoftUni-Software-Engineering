using System;
using System.Linq;
//Arrays - Lab
namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int diff = 0;
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 == 0)
                {
                    sumEven += number[i];
                }
                else
                {
                    sumOdd += number[i];
                }

                diff = sumEven - sumOdd;
            }

            Console.WriteLine(diff);
        }
    }
}
