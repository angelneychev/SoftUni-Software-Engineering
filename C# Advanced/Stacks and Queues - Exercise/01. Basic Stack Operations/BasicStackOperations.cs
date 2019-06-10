using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    public class BasicStackOperations
    {
        static void Main()
        {
            var inputCommand = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var puchCount = inputCommand[0];
            var popCount = inputCommand[1];
            var findNum = inputCommand[2];

            var inputNumbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                //.Reverse()
                .ToArray();
            var stackNumbers = new Stack<int>();

            for (int i = 0; i < puchCount; i++)
            {
                stackNumbers.Push(inputNumbers[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Contains(findNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stackNumbers.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(stackNumbers.Min());
                }
                
            }
        }
    }
}