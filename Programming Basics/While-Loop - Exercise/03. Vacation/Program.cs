using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyExcursion = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());
            int countSpend = 0;
            int countAll = 0;

            while (true)
            {
                string actionType = Console.ReadLine().ToLower();
                double actionMoney = double.Parse(Console.ReadLine());
                countAll++;
                if (actionType == "spend")
                {
                    moneyAvailable -= actionMoney;
                    countSpend++;
                }
                if (moneyAvailable < 0)
                {
                    moneyAvailable = 0;
                }
                if (countSpend == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{countAll}");
                    break;
                }
                if (actionType == "save")
                {
                    moneyAvailable += actionMoney;
                    countSpend = 0;
                }
                if (moneyAvailable >= moneyExcursion)
                {
                    Console.WriteLine($"You saved the money for {countAll} days.");
                    break;
                }
            }
        }
    }
}
