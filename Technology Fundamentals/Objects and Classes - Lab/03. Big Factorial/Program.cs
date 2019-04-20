using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//Objects and Classes - Lab
namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            BigInteger fatorial = 1;

            for (int i = 2; i <= input; i++)
            {
                fatorial *= i;
            }

            Console.WriteLine(fatorial);
        }
    }
}
