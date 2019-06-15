using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    public class CountSameValuesInArray
    {
        static void Main()
        {
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dictionaryCount = new Dictionary<double,int>();

            foreach (var counts in input)
            {
                if (dictionaryCount.ContainsKey(counts))
                {
                    dictionaryCount[counts]++;
                }
                else
                {
                    dictionaryCount[counts] = 1;
                }
            }

            foreach (var counts in dictionaryCount)
            {
                Console.WriteLine($"{counts.Key} - {counts.Value} times");
            }
        }
    }
}