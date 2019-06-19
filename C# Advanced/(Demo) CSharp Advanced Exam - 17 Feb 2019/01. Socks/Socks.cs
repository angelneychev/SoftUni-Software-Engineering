using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Socks
{
   public class Socks
    {
        static void Main()
        {
            int[] left = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackLeft = new Stack<int>(left);
            int[] right = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueRight = new Queue<int>(right);

            List<int> pairSock = new List<int>();
            while (true)
            {
                if (stackLeft.Count == 0 || queueRight.Count == 0)
                {
                    break;
                }

                int lestSock = stackLeft.Peek();
                int rightSock = queueRight.Peek();

                if (lestSock > rightSock)
                {
                    pairSock.Add(lestSock + rightSock);
                    stackLeft.Pop();
                    queueRight.Dequeue();
                }
                else if (lestSock == rightSock)
                {
                    rightSock++;
                    stackLeft.Pop();
                    stackLeft.Push(rightSock);
                    queueRight.Dequeue();

                }
                else if (lestSock < rightSock)
                {
                    stackLeft.Pop();
                }

            }

            int maxPairSock = pairSock.Max();

            Console.WriteLine(maxPairSock);
            Console.WriteLine(string.Join(" ", pairSock));
        }
    }
}
