using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Първи ред – цена на скумрията на килограм. Реално число в интервала [0.00…40.00]
            Втори ред – цена на цацата на килограм. Реално число в интервала [0.00…30.00]
            Трети ред – килограма паламуд. Реално число в интервала [0.00…50.00]
            Четвърти ред – килограма сафрид. Реално число в интервала [0.00… 70.00]
            Пети ред – килограма миди. Цяло число в интервала [0 ... 100]
                        
            mackerel
            sprats
            palm
            horse mackerel
            mussels
             */

            double priceMackerel = double.Parse(Console.ReadLine());
            double priceSprats = double.Parse(Console.ReadLine());
            double palmKg = double.Parse(Console.ReadLine());
            double horseKg = double.Parse(Console.ReadLine());
            double musselsKg = double.Parse(Console.ReadLine());

            double pricePalm = priceMackerel * 1.6;
            double priceHorse = priceSprats * 1.8;

            double totalPrice = (palmKg * pricePalm) + 
                                (horseKg * priceHorse) + 
                                (musselsKg * 7.5);

            Console.WriteLine($"{totalPrice:f2}");



        }
    }
}
