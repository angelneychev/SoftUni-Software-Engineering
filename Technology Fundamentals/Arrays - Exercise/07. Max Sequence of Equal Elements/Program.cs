using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
//Arrays - Exercise
namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            //  List<int> numbers = new List<int>()
            // { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1};
            List<int> resultList = new List<int>();
            List<int> finalList = new List<int>();
            int counter = 1;
            int maxCounter = 1;
            resultList.Add(numbers[0]);
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    resultList.Add(numbers[i + 1]);
                }
                else
                {
                    counter = 1;
                    resultList.Clear();
                    resultList.Add(numbers[i + 1]);
                }
                if (counter > maxCounter)
                {
                    finalList.Clear();
                    maxCounter = counter;
                    finalList.AddRange(resultList);
                }
            }
            if (maxCounter == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            Console.WriteLine(string.Join(" ", finalList));

        }
    }
}