using System;
//Intro and Basic Syntax - Lab
namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int theInteger = int.Parse(Console.ReadLine());
            int times = 0;
            int product = 0;

            for (int i = 1; i <= 10; i++)
            {
                times = i;
                product = theInteger * times;
                Console.WriteLine($"{theInteger} X {times} = {product}");
            }
        }
    }
}
