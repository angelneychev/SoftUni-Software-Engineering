using System;
using System.Collections.Generic;
using System.Linq;
//Задача за чорапи
namespace _01._Socks
{
    class Sock
    {
        static void Main(string[] args)
        {
            var leftInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rightInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSock = new Stack<int>(leftInput);//10 8 7 13 8 4
            Queue<int> rightSock = new Queue<int>(rightInput); //4 7 3 6 4 12
            var pair = new List<int>();
            while (leftSock.Count > 0 && rightSock.Count > 0)
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
                else if (right > left)
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