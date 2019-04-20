using System;
using System.Linq;
//Arrays - Lab
namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //0.9 1.5 2.4 2.5 3.14
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            //  double[] numbers = {0.9, 1.5, 2.4, 2.5, 3.14};
            for (int i = 0; i < numbers.Length; i++)
            {
                double temp = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[i]} => {temp}");
            }

        }
    }
}
