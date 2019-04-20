using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Lab
namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToList();

            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
