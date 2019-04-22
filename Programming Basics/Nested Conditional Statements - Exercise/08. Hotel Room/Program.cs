using System;

namespace _08._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string monts = Console.ReadLine();
            var count = double.Parse(Console.ReadLine());
            double priceStudio = 0;
            double priceApartamnet = 0;
            switch (monts)
            {
                case "May":
                case "October":
                    priceStudio = 50;
                    priceApartamnet = 65;
                    break;
                case "June":
                case "September":
                    priceStudio = 75.20;
                    priceApartamnet = 68.70;
                    break;
                case "July":
                case "August":
                    priceStudio = 76;
                    priceApartamnet = 77;
                    break;
            }

            if (count > 7 && count <= 14 && (monts == "May" || monts == "October"))
            {
                priceStudio = priceStudio - (priceStudio * 0.05);

            }
            else if (count > 14 && (monts == "May" || monts == "October"))
            {
                priceStudio = priceStudio - (priceStudio * 0.30);
            }
            else if (count > 14 && (monts == "June" || monts == "September"))
            {
                priceStudio = priceStudio - (priceStudio * 0.20);
            }
            if (count > 14)
            {
                priceApartamnet = priceApartamnet - (priceApartamnet * 0.10);
            }
            Console.WriteLine($"Apartment: {(priceApartamnet * count):F2} lv.");
            Console.WriteLine($"Studio: {(priceStudio * count):F2} lv.");
        }
    }
}
