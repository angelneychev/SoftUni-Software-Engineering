using System;
//изпит
namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysVacantion = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int countPeaple = int.Parse(Console.ReadLine());
            double fuelPerKilometar = double.Parse(Console.ReadLine());
            double foodPrisePerson = double.Parse(Console.ReadLine());
            double hotelPriseRoom = double.Parse(Console.ReadLine());
            double sumFuel = 0;

            if (countPeaple > 10)
            {
                hotelPriseRoom = hotelPriseRoom - (hotelPriseRoom * 0.25);
            }

            double priceAllFood = foodPrisePerson * daysVacantion * countPeaple;
            double priceAllhotel = hotelPriseRoom * daysVacantion * countPeaple;

            double currentExpenses = priceAllhotel + priceAllFood;

            for (int i = 1; i <= daysVacantion; i++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                sumFuel = travelledDistance * fuelPerKilometar;
                currentExpenses += sumFuel;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses = currentExpenses * 1.4;
                }
                if (i % 7 == 0)
                {
                    double bonus = currentExpenses / countPeaple;
                    currentExpenses -= bonus;
                }
                if (budget <= currentExpenses)
                {
                    break;
                }
            }
            if (budget >= currentExpenses)
            {
                Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):f2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses - budget):F2}$ more.");
            }
        }
    }
}
