using System;

namespace _07._House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double greanColor = ((2 * (x * y)) - (2 * (1.5 * 1.5)) +
                                 (2 * (x * x)) - (2 * 1.2)) / 3.4;
            double readColor = ((2 * (x * y)) + (2 * (x * h / 2))) / 4.3;

            Console.WriteLine($"{greanColor:f2}");
            Console.WriteLine($"{readColor:f2}");
        }
    }
}
