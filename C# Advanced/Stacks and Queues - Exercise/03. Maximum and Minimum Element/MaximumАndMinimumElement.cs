using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    public class MaximumАndMinimumElement
    {
        static void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();

            for (int i = 0; i < inputCount; i++)
            {
                var inputNumbers = Console.ReadLine().Split(' ');

                var command = inputNumbers[0];
                
                if (command == "1")
                {
                    var pushNumber = inputNumbers[1];
                    numbers.Push(int.Parse(pushNumber));
                }
                else if (command == "2" && numbers.Count >=1)
                {
                    numbers.Pop();
                }
                else if (command == "3" && numbers.Count >= 1)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (command == "4" && numbers.Count >= 1)
                {
                    Console.WriteLine(numbers.Min());
                }

            }

            Console.WriteLine(string.Join(", ", numbers.ToArray()));



        }
    }
}