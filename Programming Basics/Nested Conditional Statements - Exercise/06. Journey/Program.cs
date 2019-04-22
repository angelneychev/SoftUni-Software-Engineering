using System;

namespace _06._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            string seasons = Console.ReadLine();
            double price = 0;
            string destination = "";
            string type = "";

            if (budget <= 100)
            {
                if (seasons == "summer")
                {
                    budget = budget * 0.3;
                    destination = "Bulgaria";
                    type = "Camp";
                }
                else if (seasons == "winter")
                {
                    budget = budget * 0.7;
                    destination = "Bulgaria";
                    type = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                if (seasons == "summer")
                {
                    budget = budget * 0.4;
                    destination = "Balkans";
                    type = "Camp";
                }
                else if (seasons == "winter")
                {
                    budget = budget * 0.8;
                    destination = "Balkans";
                    type = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                budget = budget * 0.90;
                destination = "Europe";
                type = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {budget:F2}");
        }
    }
}
