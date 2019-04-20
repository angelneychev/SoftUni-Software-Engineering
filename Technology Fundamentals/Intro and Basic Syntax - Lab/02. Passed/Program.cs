using System;
using System.Runtime.InteropServices;
//Intro and Basic Syntax - Lab
namespace _02._Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            if (input >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
