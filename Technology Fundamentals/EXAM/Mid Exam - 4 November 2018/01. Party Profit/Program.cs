using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companionsCount = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int coins = days *50; //Every day, you are earning 50 coins, 
            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    companionsCount -= 2;
                }
                //but every 15th (fifteenth) day 5 (five) new companions are joined at the beginning of the day
                if (i % 15 == 0)
                {
                    companionsCount += 5;
                }
                //Every 10th (tenth) day at the start of the day, 2 (two) of your companions leave, 

                //Every 3rd (third) day, you have a motivational party, spending 3 coins per companion for drinking water. 
                if (i % 3 == 0)
                {
                    coins -= companionsCount * 3;
                }
                //Every 5th (fifth) day you slay a boss monster and you gain 20 coins per companion.
                //But if you have a motivational party the same day, you spent additional 2 coins per companion. 
                if (i % 5 == 0)
                {
                    coins += companionsCount * 20;
                    if (i % 3 == 0)
                    {
                        coins -= companionsCount * 2;
                    }
                }
                //but you also spent 2 coin per companion for food. 
                coins -= companionsCount * 2;
            }

            Console.WriteLine($"{companionsCount} companions received {coins/companionsCount} coins each.");
        }
    }
}
