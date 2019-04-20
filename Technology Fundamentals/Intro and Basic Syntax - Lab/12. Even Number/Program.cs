using System;
using System.Net.WebSockets;
//Intro and Basic Syntax - Lab
namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int convertNumbewr = Math.Abs(inputNumber);

            while (true)
            {

                if (inputNumber % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");

                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(inputNumber)}");
                    break;
                }
                inputNumber = int.Parse(Console.ReadLine());
            }
        }
    }
}
