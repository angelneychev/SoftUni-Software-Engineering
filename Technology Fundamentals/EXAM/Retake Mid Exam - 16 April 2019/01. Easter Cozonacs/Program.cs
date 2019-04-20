using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double priceFloor = double.Parse(Console.ReadLine());

            double priceEggs = priceFloor * 0.75;
            double priceMilk = (priceFloor * 1.25)/4;
           // double quantityMilkPrice =  0.250;
           double priceCozonacs = priceFloor + priceEggs + priceMilk;
           int eggs = 0;
           int count = 0;
           int cozonacs = 0;
           while (budget > priceCozonacs)
           {
               count++;
               budget -= priceCozonacs;
               eggs += 3;
               cozonacs++;
               if (count % 3 == 0)
               {
                   int newEggs = cozonacs - 2;
                   eggs -= newEggs;
               }
           }

           Console.WriteLine($"You made {cozonacs} cozonacs! Now you have {eggs} eggs and {budget:f2}BGN left.");
        }
    }
}
