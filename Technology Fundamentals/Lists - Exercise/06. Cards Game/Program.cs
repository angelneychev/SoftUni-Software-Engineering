using System;
using System.Collections.Generic;
using System.Linq;
//Lists - Exercise
namespace _06._Cards_Game
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                int first = firstPlayer[0];
                int second = secondPlayer[0];
                if (first > second)
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (second > first)
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                    secondPlayer.RemoveAt(0);
                    firstPlayer.RemoveAt(0);
                }
                else if (first == second)
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }
            if (firstPlayer.Count > 0)
            {
                int sumFirstPayer = firstPlayer.Sum();
                Console.WriteLine($"First player wins! Sum: {sumFirstPayer}");
            }
            else if (secondPlayer.Count > 0)
            {
                int sumSecondPayer = secondPlayer.Sum();
                Console.WriteLine($"Second player wins! Sum: {sumSecondPayer}");
            }
        }
    }
}

