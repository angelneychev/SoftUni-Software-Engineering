using System;

namespace _04._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            var budget = double.Parse(Console.ReadLine());
            double total = 0;
            if (flowers == "Roses" && quantity > 80)
            {
                total = ((5 - (5 * 0.1)) * quantity);
            }
            else if (flowers == "Roses" && quantity <= 80)
            {
                total = (5 * quantity);
            }
            else if (flowers == "Dahlias" && quantity > 90)
            {
                total = ((3.8 - (3.8 * 0.15)) * quantity);
            }
            else if (flowers == "Dahlias" && quantity <= 90)
            {
                total = (3.8 * quantity);
            }
            else if (flowers == "Tulips" && quantity > 80)
            {
                total = ((2.8 - (2.8 * 0.15)) * quantity);
            }
            else if (flowers == "Tulips" && quantity <= 80)
            {
                total = (2.8 * quantity);
            }
            else if (flowers == "Narcissus" && quantity < 120)
            {
                total = ((3 + (3 * 0.15)) * quantity);
            }
            else if (flowers == "Narcissus" && quantity >= 120)
            {
                total = (3 * quantity);
            }
            else if (flowers == "Gladiolus" && quantity < 80)
            {
                total = ((2.5 + (2.5 * 0.2)) * quantity);
            }
            else if (flowers == "Gladiolus" && quantity >= 80)
            {
                total = (2.5 * quantity);
            }
            double sum = budget - total;
            if (sum >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flowers} and {sum:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(total - budget):F2} leva more.");
            }
        }
    }
}
