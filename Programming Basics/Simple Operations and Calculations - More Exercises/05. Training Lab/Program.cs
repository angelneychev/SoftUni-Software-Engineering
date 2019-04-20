using System;

namespace _05._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine()) * 100;

            double h = double.Parse(Console.ReadLine()) * 100;

            int width = ((int)h - 100) / 70;
            int height = (int) w / 120;

            int total = (width * height) - 3;
            Console.WriteLine(total);

        }
    }
}
