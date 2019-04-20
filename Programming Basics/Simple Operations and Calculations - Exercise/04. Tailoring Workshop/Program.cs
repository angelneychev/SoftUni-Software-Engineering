using System;

namespace _04._Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = int.Parse(Console.ReadLine()); //Брой правоъгълни маси 
            var l = double.Parse(Console.ReadLine()); //Дължина на правоъгълните маси в метри 
            var w = double.Parse(Console.ReadLine()); //Широчина на правоъгълните маси в метри 
            double rectangul = table * (l + 2 * 0.30) * (w + 2 * 0.30);
            double square = table * (l / 2) * (l / 2);
            double priceUSD = rectangul * 7 + square * 9;
            double priceBGN = priceUSD * 1.85;
            Console.WriteLine($"{priceUSD:F2} USD");
            Console.WriteLine($"{priceBGN:F2} BGN");
        }
    }
}
