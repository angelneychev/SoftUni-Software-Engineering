using System;

namespace _04._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int vegetablesKg = int.Parse(Console.ReadLine());
            int fruitsKg = int.Parse(Console.ReadLine());

            double totalPrice = ((priceBVegetables * vegetablesKg)
                                + (priceFruits * fruitsKg)) / 1.94;
            Console.WriteLine(totalPrice);


        }
    }
}
