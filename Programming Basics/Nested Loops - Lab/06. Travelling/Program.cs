using System;

namespace _06._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double sumMoney = 0;
            while (true)
            {
                if (destination == "End")
                {
                    break;
                }
                double budget = double.Parse(Console.ReadLine());

                while (budget > sumMoney)
                {
                    double money = double.Parse(Console.ReadLine());
                    sumMoney += money;

                    if (sumMoney >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        sumMoney = 0;
                        break;
                    }
                }
                destination = Console.ReadLine();
            }
        }
    }
}
