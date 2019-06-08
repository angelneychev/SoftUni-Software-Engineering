using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Hot_Potato
{
    public class HotPotato
    {
        static void Main()
        {
            var children = Console.ReadLine().Split(' ');
            var number = int.Parse(Console.ReadLine());
            var childrenQueue = new Queue<string>(children);
            while (childrenQueue.Count !=1)
            { 
                for (int i = 1; i < number; i++)
            {
                childrenQueue.Enqueue(childrenQueue.Dequeue());
            }

                Console.WriteLine($"Removed {childrenQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {childrenQueue.Dequeue()}");
        }
    }
}
