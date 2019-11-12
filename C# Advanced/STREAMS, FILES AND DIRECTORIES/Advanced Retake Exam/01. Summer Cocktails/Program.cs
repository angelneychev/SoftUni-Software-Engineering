using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputIngredients = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputFreshness = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredientsQueue = new Queue<int>(inputIngredients);
                Stack<int> freshnessStack = new Stack<int>(inputFreshness);
            Dictionary<string, int> cocktails = new Dictionary<string, int>
            {
                {"Mimosa", 0}, {"Daiquiri", 0}, {"Sunshine", 0}, {"Mojito", 0}
            };

            while (ingredientsQueue.Count > 0 && freshnessStack.Count > 0)
            {

                int ingredients = ingredientsQueue.Peek();
                int freshness = freshnessStack.Peek();

                if (ingredients == 0)
                {
                    ingredientsQueue.Dequeue();
                    ingredients = ingredientsQueue.Peek();
                }
                int sum = ingredients * freshness;

                if (sum == 150)
                {
                    cocktails["Mimosa"] += 1;
                    ingredientsQueue.Dequeue();
                    freshnessStack.Pop();

                }
                else if (sum == 250)
                {
                    cocktails["Daiquiri"] += 1;
                    ingredientsQueue.Dequeue();
                    freshnessStack.Pop();

                }
                else if (sum == 300)
                {
                    cocktails["Sunshine"] += 1;
                    ingredientsQueue.Dequeue();
                    freshnessStack.Pop();

                }
                else if (sum == 400)
                {
                    cocktails["Mojito"] += 1;
                    ingredientsQueue.Dequeue();
                    freshnessStack.Pop();

                }
                else
                {
                    freshnessStack.Pop();
                    ingredients += 5;
                    ingredientsQueue.Dequeue();
                    ingredientsQueue.Enqueue(ingredients);
                }
            }

            int count = 0;
            foreach (var kvp in cocktails.OrderBy(x => x.Key))
            {
                if (kvp.Value > 0)
                {
                    count++;
                }
            }

            if (count == 4)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            int sumIngredients = 0;
            if (ingredientsQueue.Count >0)
            {
                foreach (var item in ingredientsQueue)
                {
                    sumIngredients += item;
                }

                Console.WriteLine($"Ingredients left: {sumIngredients}");
            }

            foreach (var kvp in cocktails.OrderBy(x=>x.Key))
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
                
            }
        }
    }
}
