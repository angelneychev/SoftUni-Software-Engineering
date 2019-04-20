using System;
//Intro and Basic Syntax - Lab
namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int theInteger = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            int product = 0;

            if (times < 10)
            {
                for (int i = times; i <= 10; i++)
                {
                    times = i;
                    product = theInteger * times;
                    Console.WriteLine($"{theInteger} X {times} = {product}");
                }
            }
            else
            {
                product = theInteger * times;
                Console.WriteLine($"{theInteger} X {times} = {product}");
            }


        }
    }
}
