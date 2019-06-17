using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Make_a_Salad
{
   public class MakeSalad
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<string> salads = new Queue<string>(input);
            Stack<int> calories = new Stack<int>(numbers);
            Queue<int> finishedSalads = new Queue<int>();
            int currentDiff = 0;
            int sumCalorie = 0;
            int saladCalorie = 0;
            if (calories.Count >0)
            {
                saladCalorie = calories.Peek();
            }
            

            while (salads.Count !=0)
            {
                if (calories.Count == 0)
                {
                    break;
                }
                string vegetable = salads.Peek();
                switch (vegetable)
                    {
                        case "tomato":
                            sumCalorie += 80;
                            vegetable = salads.Dequeue();
                            break;
                        case "carrot":
                            sumCalorie += 136;
                            vegetable = salads.Dequeue();
                            break;
                        case "lettuce":
                            sumCalorie += 109;
                            vegetable = salads.Dequeue();
                            break;
                        case "potato":
                            sumCalorie += 215;
                            vegetable = salads.Dequeue();
                            break;
                    }

                currentDiff = saladCalorie - sumCalorie;
                sumCalorie = 0;
                saladCalorie = currentDiff;
                if (currentDiff < 0)
                {
                    finishedSalads.Enqueue(calories.Pop());
                    if (calories.Count>0)
                    {
                        saladCalorie += calories.Peek();
                    }
                    
                }
            }
            Console.WriteLine(string.Join(" ", finishedSalads));
            if (calories.Count >0)
            {
                Console.WriteLine(string.Join(" ",calories));
            }
            else if (salads.Count >0)
            {
                Console.WriteLine(string.Join(" ", salads));
            }
        }
    }
}
