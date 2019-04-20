using System;
// Data Types and Variables - Lab
namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputMeter = int.Parse(Console.ReadLine());
            double convertKilometer = (double)inputMeter / 1000;
            Console.WriteLine($"{convertKilometer:f2}");

        }
    }
}
