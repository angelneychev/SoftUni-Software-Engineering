using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Exercise
namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);

            }
            int sum = numbers.Sum();
            Console.Write(string.Join(" ", numbers));
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
