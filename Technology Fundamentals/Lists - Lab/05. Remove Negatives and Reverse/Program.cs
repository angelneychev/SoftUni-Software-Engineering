using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> positivNumbers = new List<int>();

            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] >= 0)
                {
                    positivNumbers.Add(number[i]);
                }
            }
            if (positivNumbers.Count > 0)
            {
                positivNumbers.Reverse();
                Console.WriteLine(string.Join(" ", positivNumbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
