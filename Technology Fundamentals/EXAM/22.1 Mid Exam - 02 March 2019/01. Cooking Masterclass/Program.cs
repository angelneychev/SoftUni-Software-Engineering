using System;
//Programming Fundamentals - Мid Exam - 02 March 2019
namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine()); // Брашно
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine()); // Престилка

            double sum = 0;
            int freePackages = students / 5;
            double sumOfApron = (Math.Ceiling(students + (students * 0.2))) * priceOfApron;
            double sumOfEgg = students * (priceOfEgg * 10);
            double sumOfFlour = (students - freePackages) * priceOfFlour;

            sum = (sumOfApron) + sumOfEgg + sumOfFlour;

            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(sum - budget):f2}$ more needed.");
            }





        }
    }
}
