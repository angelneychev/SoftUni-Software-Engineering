using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    public class SpaceshipCrafting
    {
        static void Main()
        {
            int[] inputLiquid = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputItem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquidQueue = new Queue<int>(inputLiquid);
            Stack<int> itemStack = new Stack<int>(inputItem);
            Dictionary<string, int> allMaterial = new Dictionary<string, int>
            {
                {"Glass", 0}, {"Aluminium", 0}, {"Lithium", 0}, {"Carbon fiber", 0}
            };

            while (liquidQueue.Count > 0 && itemStack.Count > 0)
            {
                int liquid = liquidQueue.Peek();
                int item = itemStack.Peek();
                int sum = liquid + item;

                if (sum == 25)
                {
                    allMaterial["Glass"] += 1;
                    liquidQueue.Dequeue();
                    itemStack.Pop();
                }
                else if (sum == 50)
                {
                    allMaterial["Aluminium"] += 1;
                    liquidQueue.Dequeue();
                    itemStack.Pop();
                }
                else if (sum == 75)
                {
                    allMaterial["Lithium"] += 1;
                    liquidQueue.Dequeue();
                    itemStack.Pop();
                }
                else if (sum == 100)
                {
                    allMaterial["Carbon fiber"] += 1;
                    liquidQueue.Dequeue();
                    itemStack.Pop();
                }
                else
                {
                    liquidQueue.Dequeue();
                    itemStack.Pop();
                    item += 3;
                    itemStack.Push(item);
                }
            }
            int count = 0;
            foreach (var kvp in allMaterial.OrderBy(x => x.Key))
            {
                if (kvp.Value > 0)
                {
                    count++;
                }
            }

            if (count >= 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");

            }
            if (liquidQueue.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidQueue)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }
            if (itemStack.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", itemStack)}");
            }
            else
            {
                Console.WriteLine($"Physical items left: none");
            }
            foreach (var kvp in allMaterial.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
