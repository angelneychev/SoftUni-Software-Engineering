using System;

namespace _01._Rage_Expenses
{
    class Program
    {
        static void Main()
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double totalMoney = 0;
            int count = 0;
            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoney += headsetPrice;
                }

                if (i % 3 == 0)
                {
                    totalMoney += mousePrice;
                    if (i % 2 == 0)
                    {
                        totalMoney += keyboardPrice;
                        count++;
                    }
                }

                if (count == 2)
                {
                    totalMoney += displayPrice;
                    count = 0;
                }
            }

            Console.WriteLine($"Rage expenses: {totalMoney:f2} lv.");
        }
    }
}
