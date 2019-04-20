using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Exercise
namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 4 3 2
            //4 3 2
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                bool isBigger = true;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isBigger = false;
                    }
                }
                if (isBigger)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            // Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
