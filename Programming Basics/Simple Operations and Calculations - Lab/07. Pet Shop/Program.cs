using System;

namespace _07._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double totalPrice = (dogsCount * 2.50) + (otherAnimals * 4);

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
