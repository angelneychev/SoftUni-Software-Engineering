using System;

namespace _08._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            //double a = oldLili % 2;
            //Console.WriteLine(a);
            double pricePeralnq = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());
            int countMoney = 0;
            double bonus = 0;
            int countToys = 0;
            double allMoney = 0;
            double moneyToys = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    countMoney++;
                }
                else
                {
                    countToys++;
                }
            }
            for (int i = 1; i <= countMoney; i++)
            {
                bonus += 10 * i;
            }
            bonus -= countMoney;
            moneyToys = countToys * priceToys;
            allMoney = bonus + moneyToys;

            if (allMoney >= pricePeralnq)
            {
                double sum = allMoney - pricePeralnq;
                Console.WriteLine($"Yes! {sum:F2}");
            }
            else
            {
                double sum1 = pricePeralnq - allMoney;
                Console.WriteLine($"No! {sum1:F2}");
            }
        }
    }
}
