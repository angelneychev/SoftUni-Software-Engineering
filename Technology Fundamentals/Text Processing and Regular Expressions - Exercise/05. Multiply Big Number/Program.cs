using System;
using System.Linq;
using System.Numerics;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            BigInteger numbers = input * number;

            Console.WriteLine(numbers);

        }
    }
}
