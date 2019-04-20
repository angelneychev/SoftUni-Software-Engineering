using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
On the 1st line, you are going to receive the days of the adventure – an integer in the range [1…100]
On the 2nd line – the count of players – an integer in the range [0 – 1000]
On the 3rd line - the group’s energy – a real number in the range [1 - 50000]
On the 4th line – water per day for one person – a real number [0.00 – 1000.00]
On the 5th line – food per day for one person – a real number [0.00 – 1000.00]
On the next n lines – one for each of the days – the amount of energy loss– a real number in the range [0.00 - 1000]
You will always have enough food and water.
             */


            int daysOfAdventure = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterOnePersonDay = double.Parse(Console.ReadLine());
            double foodOnePersonDay = double.Parse(Console.ReadLine());

            double totalWater = daysOfAdventure * countOfPlayers * waterOnePersonDay;
            double totalFood = daysOfAdventure * countOfPlayers * foodOnePersonDay;

            for (int i = 1; i <= daysOfAdventure; i++)
            {
                double inputEnergy = double.Parse(Console.ReadLine());
                groupEnergy -= inputEnergy;
                if (groupEnergy <= 0)
                {
                    break;

                }
                if (i % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater -= totalWater * 0.3;
                }
                if (i % 3 == 0)
                {
                    groupEnergy += groupEnergy * 0.10;
                    totalFood -= (totalFood / countOfPlayers);
                }
            }
            if (groupEnergy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
        }
    }
}
