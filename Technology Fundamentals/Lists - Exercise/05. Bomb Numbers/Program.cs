using System;
using System.Collections.Generic;
using System.Linq;
//Lists - Exercise
namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 2 4 2 2 2 9
            //1 {2}{2}[4]{2}{2} 2 9
            //4 2
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            //  List<int> numbers = new List<int>() { 1, 4, 4, 2, 8, 9, 1 };

            int[] commandLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            //int[] commandLine = { 9, 3 };
            int power = commandLine[0];
            int countNumber = commandLine[1];

            //    numbers.RemoveRange(1, 2);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == power)
                {
                    int index = i - countNumber;
                    int indexRight = i + countNumber;
                    if (index < 0)
                    {
                        int sumCountRemove = ((countNumber + countNumber) + 1) + index;
                        index = 0;
                        numbers.RemoveRange(index, sumCountRemove);
                    }
                    else if (indexRight > numbers.Count)
                    {
                        index = i - countNumber;
                        int sumCountRemove = numbers.Count - index;
                        numbers.RemoveRange(index, sumCountRemove);
                    }
                    else
                    {
                        int sumCountRemove = (countNumber + countNumber) + 1;
                        numbers.RemoveRange(index, sumCountRemove);
                        i = -1;
                    }
                }
            }
            int sumTotal = numbers.Sum();
            Console.WriteLine(sumTotal);
        }
    }
}
