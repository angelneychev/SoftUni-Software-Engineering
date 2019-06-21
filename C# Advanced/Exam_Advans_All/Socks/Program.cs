using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            var rightInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> leftSock =new Stack<int>(leftInput);
            Queue<int> rightSock = new Queue<int>(rightInput);
            var pair = new List<int>();

            while (leftSock.Count >0 && rightSock.Count > 0)
            {
                int left = leftSock.Peek();
                int right = rightSock.Peek();

                if (left > right)
                {
                    int sum = left + right;
                    pair.Add(sum);
                    leftSock.Pop();
                    rightSock.Dequeue();

                }
                else if (left < right)
                {
                    leftSock.Pop();
                }
                else if (left == right)
                {
                    rightSock.Dequeue();
                    left++;
                    leftSock.Pop();
                    leftSock.Push(left);
                }

            }

            int maxPair = pair.Max();
            Console.WriteLine(maxPair);
            Console.WriteLine(string.Join(" ", pair));
        }
    }
}