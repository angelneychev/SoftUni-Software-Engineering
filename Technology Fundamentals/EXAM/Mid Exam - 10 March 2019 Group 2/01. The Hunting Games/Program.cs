using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());

            double totalWater = days * players * water;
            double totalFood = days * players * food;

            double lossEnergy = double.Parse(Console.ReadLine());
            bool temp = true;
                for (int i = 1; i <= days; i++)
                {
                if (energy - lossEnergy > 0)
                {
                    energy -= lossEnergy;
                }
                else
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    temp = false;
                    break;
                }
                if (i % 2 == 0)
                    {
                        energy += energy * 0.05;
                        totalWater -=totalWater * 0.3;
                    }

                    if (i % 3 == 0)
                    {
                        totalFood -= totalFood / players;
                        energy += energy * 0.1;
                    }

                    if (i == days)
                    {
                        break;
                    }
                    lossEnergy = double.Parse(Console.ReadLine());
                }
            if (temp)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}
