using System;

namespace _07._Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskePrise = double.Parse(Console.ReadLine());
            double quantiBeer = double.Parse(Console.ReadLine());
            double quantiWine = double.Parse(Console.ReadLine());
            double quantiRakia = double.Parse(Console.ReadLine());
            double quantiWhiske = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskePrise / 2; //Цена на ракията за литър
            double winePrice = rakiaPrice - (0.4 * rakiaPrice); //Цена на виното за литър
            double beerPrice = rakiaPrice - (0.8 * rakiaPrice); //Цена на бирата за литър


            double rakiaCost = rakiaPrice * quantiRakia;
            double wineCost = winePrice * quantiWine;
            double beerCost = beerPrice * quantiBeer;
            double wiskeCost = quantiWhiske * whiskePrise;

            double totalsum = rakiaCost + wineCost + beerCost + wiskeCost;

            Console.WriteLine($"{totalsum:F2}");
        }
    }
}
