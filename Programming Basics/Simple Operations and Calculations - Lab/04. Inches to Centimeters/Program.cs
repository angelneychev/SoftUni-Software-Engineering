using System;

namespace _04._Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            var inch = double.Parse(Console.ReadLine());
            double cm = 2.54;
            var conv = inch * cm;
            Console.WriteLine($"{conv:f2}");
        }
    }
}
