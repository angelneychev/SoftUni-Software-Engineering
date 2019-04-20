﻿using System;
using System.Linq;

namespace _4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sorted = numbers.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join(" ", sorted));

        }
    }
}
