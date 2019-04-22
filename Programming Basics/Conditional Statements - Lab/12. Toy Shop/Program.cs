using System;

namespace _12._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double safari = double.Parse(Console.ReadLine());
            int puzzel = int.Parse(Console.ReadLine());
            int doyls = int.Parse(Console.ReadLine());
            int bear = int.Parse(Console.ReadLine());
            int minnons = int.Parse(Console.ReadLine());
            int car = int.Parse(Console.ReadLine());

            double puzzelPrice = 2.60;
            double doylsPrice = 3;
            double bearPrice = 4.10;
            double minnonsPrice = 8.20;
            double carPrice = 2;

            double totalSum = (puzzel * puzzelPrice) + (doyls * doylsPrice) + (bear * bearPrice) + (minnons * minnonsPrice) + (car * carPrice);
            double totalCount = puzzel + doyls + bear + minnons + car;

            if (totalCount >= 50)
            {
                totalSum = (1 - 0.25) * totalSum;
            }

            totalSum = (1 - 0.1) * totalSum;

            if (totalSum >= safari)
            {

                Console.WriteLine($"Yes! {(totalSum - safari):F2} lv left.");

            }
            else
            {
                Console.WriteLine($"Not enough money! {(safari - totalSum):F2} lv needed.");
            }
        }
    }
}
