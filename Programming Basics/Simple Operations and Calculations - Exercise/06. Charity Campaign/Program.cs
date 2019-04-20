using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = int.Parse(Console.ReadLine()); //1.	Броят на дните, в които тече кампанията – цяло число в интервала [0 … 365]
            var baker = int.Parse(Console.ReadLine()); //2.	Броят на сладкарите – цяло число в интервала [0 … 1000]
            var cake = int.Parse(Console.ReadLine()); //3.	Броят на тортите – цяло число в интервала [0… 2000]
            var waffels = int.Parse(Console.ReadLine()); // 4.	Броят на гофретите – цяло число в интервала [0 … 2000]
            var pancake = int.Parse(Console.ReadLine()); //5.	Броят на палачинките – цяло число в интервала [0 … 2000]

            double totalCakePrice = cake * 45; // Изчисляваме колко струват торитите
            double totalWaffelsPrice = waffels * 5.80; // Изчисляваме колко струват гофретите
            double totalPancakePrice = pancake * 3.20; // Изчисляваме колко струват палачинките

            double totalSum = (totalCakePrice + totalWaffelsPrice + totalPancakePrice) * baker; // Обща сума за един ден
            double totalPriceAll = totalSum * day; // Сума събрана от цялата кампания
            double totalPriceProduct = totalPriceAll - (totalPriceAll * 1 / 8); // Сума след покриване на разходите

            Console.WriteLine($"{totalPriceProduct:F2}");
        }
    }
}
