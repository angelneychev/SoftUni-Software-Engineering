using System;
using System.Linq;
//Arrays - Exercise
namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lineNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            // int[] lineNumber = {1, 7, 6, 2, 19, 23};
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineNumber.Length - 1; i++)
            {
                for (int j = i + 1; j < lineNumber.Length; j++)
                {
                    if (lineNumber[i] + lineNumber[j] == number)
                    {
                        Console.WriteLine(lineNumber[i] + " " + lineNumber[j]);
                    }
                }

            }
        }
    }
}
