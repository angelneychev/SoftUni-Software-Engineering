using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Exercise
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //51 47 32 61 21
            //32 61 21 51 47
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                int leftIndex = numbers[0];

                numbers.Add(leftIndex);
                numbers.RemoveAt(0);
            }

            Console.Write(string.Join(" ", numbers));
        }
    }
}
