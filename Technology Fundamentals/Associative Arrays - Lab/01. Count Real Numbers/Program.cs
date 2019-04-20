﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            foreach (var number in numbers)
            {
                if (!counts.ContainsKey(number))
                {
                    counts.Add(number, 1);
                }
                else
                {
                    counts[number]++;
                }
            }

            foreach (var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }

        }
    }
}
