using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                var firstNumber = numbers[i];
                var secondNumber = numbers[numbers.Count - 1 - i];
                var resultNumber = firstNumber + secondNumber;
                result.Add((int)resultNumber);

            }

            if (numbers.Count % 2 == 1)
            {
                var middle = numbers[numbers.Count / 2];
                result.Add((int)middle);
            }


            Console.WriteLine(string.Join(" ", result));
        }
    }
}
