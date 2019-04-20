using System;
// Data Types and Variables - Lab
namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            double dolars = pounds * 1.31;

            Console.WriteLine($"{dolars:f3}");
        }
    }
}
