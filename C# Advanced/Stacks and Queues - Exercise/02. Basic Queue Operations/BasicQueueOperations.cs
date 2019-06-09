using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
   public class BasicQueueOperations
    {
        static void Main()
        {
            var inputCommand = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var enqueueCount = inputCommand[0];
            var dequeueCount = inputCommand[1];
            var findNum = inputCommand[2];

            var inputNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                //.Reverse()
                .ToArray();
            var queueNumbers = new Queue<int>();

            for (int i = 0; i < enqueueCount; i++)
            {
                queueNumbers.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < dequeueCount; i++)
            {
                queueNumbers.Dequeue();
            }

            if (queueNumbers.Contains(findNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queueNumbers.Any())
                {
                    Console.WriteLine(queueNumbers.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
