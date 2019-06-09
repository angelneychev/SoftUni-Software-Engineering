using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    public class FastFood
    {
        static void Main()
        {
            int foodCount = int.Parse(Console.ReadLine());

            var queueOrder = new Queue<int>();

            var inputOrder = Console.ReadLine().Split(' ');
            int count = 0;

            foreach (var order in inputOrder)
            {
                count++;
                queueOrder.Enqueue(int.Parse(order));
            }

            var endOrder = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                int orderFood = queueOrder.Peek();
                foodCount -= orderFood;
                if (foodCount >= 0)
                {
                    endOrder.Enqueue(queueOrder.Dequeue());
                }
                else
                {
                    Console.WriteLine(endOrder.Max());
                    Console.Write($"Orders left: {queueOrder.Peek()}");
                    break;
                }
            }

            if (queueOrder.Count == 0)
            {
                Console.WriteLine(endOrder.Max());
                Console.WriteLine("Orders complete");
            }
        }
    }
}