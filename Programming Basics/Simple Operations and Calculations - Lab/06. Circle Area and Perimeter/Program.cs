using System;

namespace _06._Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = double.Parse(Console.ReadLine());

            var area = Math.PI * r * r;
            var perimete = 2 * Math.PI * r;

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{perimete:f2}");
        }
    }
}
