using System;

namespace _05._Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = Double.Parse(Console.ReadLine());
            var w = Double.Parse(Console.ReadLine());
            var a = Double.Parse(Console.ReadLine()) * 100;

            double hallAria = (l * 100) * (w * 100);

            double aria = a * a;
            double bench = hallAria / 10;
            double freeSpase = hallAria - aria - bench;

            double danseCount = freeSpase / (40 + 7000);
            Console.WriteLine(Math.Floor(danseCount));
        }
    }
}
