using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class TrojanInvasion
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] plates = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> plateQueue = new Queue<int>(plates);

            Stack<int> warriorsStack = new Stack<int>();
            for (int i = 1; i <= n; i++)
            {
                int[] warriors = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                warriorsStack = new Stack<int>(warriors);

                if (i % 3 == 0)
                {
                    int addtionalPlate = int.Parse(Console.ReadLine());
                    plateQueue.Enqueue(addtionalPlate);
                }

                while (plateQueue.Count > 0 && warriorsStack.Count > 0)
                {
                    int currentWarrior = warriorsStack.Pop(); // направо го вадим, защото той ще е променен и след това ще го върнем
                    int currentPlate = plateQueue.Dequeue();

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriorsStack.Push(currentWarrior);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                        plateQueue.Enqueue(currentPlate);
                        // това се прави, защото извадена и след това добавена стойност е последна, а трябва да е първа.
                        for (int j = 0; j < plateQueue.Count - 1; j++)
                        {
                            int revers = plateQueue.Peek();
                            plateQueue.Dequeue();
                            plateQueue.Enqueue(revers);
                        }
                    }
                }

                if (plateQueue.Count == 0)
                {
                    break;
                }
            }

            if (plateQueue.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriorsStack)}");
            }
            else if (warriorsStack.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plateQueue)}");
            }
        }
    }
}
