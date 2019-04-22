using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            string seasons = Console.ReadLine();
            var countFisher = int.Parse(Console.ReadLine());
            double price = 0;
            switch (seasons)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }
            if (countFisher <= 6)
            {
                price = price - (price * 0.1);
            }
            else if (countFisher > 6 && countFisher <= 11)
            {
                price = price - (price * 0.15);
            }
            else if (countFisher > 11)
            {
                price = price - (price * 0.25);
            }
            if (countFisher % 2 == 0 && seasons != "Autumn")
            {
                price = price - (price * 0.05);
            }

            double total = budget - price;
            if (total >= 0)
            {
                Console.WriteLine($"Yes! You have {total:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {((price - budget)):F2} leva.");
            }
        }
    }
}
