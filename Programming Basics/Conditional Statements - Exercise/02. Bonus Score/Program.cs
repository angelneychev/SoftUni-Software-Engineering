using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int bonus = int.Parse(Console.ReadLine());
            var bonusScore = 0.0;

            if (bonus <= 100)
            {
                bonusScore = 5;
            }
            else if (bonus > 100 && bonus <= 1000)
            {
                bonusScore = bonus * 0.2;
            }
            else if (bonus > 1000)
            {
                bonusScore = bonus * 0.1;
            }
            if (bonus % 2 == 0)
            {
                bonusScore = bonusScore + 1;
            }
            else if (bonus % 10 == 5)
            {
                bonusScore = bonusScore + 2;
            }
            Console.WriteLine(bonusScore);
            Console.WriteLine(bonus + bonusScore);
        }
    }
}
