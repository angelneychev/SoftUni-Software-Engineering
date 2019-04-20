using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            var USD = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Round(USD * 1.79549, 2));
        }
    }
}
