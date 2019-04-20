using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumber = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumber = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> allNumberList = new List<int>();

            int minCount = Math.Min(firstNumber.Count, secondNumber.Count);


            for (int i = 0; i < minCount; i++)
            {
                allNumberList.Add(firstNumber[i]);
                allNumberList.Add(secondNumber[i]);

            }
            List<int> biggerList;

            if (minCount == firstNumber.Count)
            {
                biggerList = secondNumber;
            }
            else
            {
                biggerList = firstNumber;
            }

            for (int i = minCount; i < biggerList.Count; i++)
            {
                allNumberList.Add(biggerList[i]);
            }

            Console.WriteLine(string.Join(" ", allNumberList));
        }
    }
}
