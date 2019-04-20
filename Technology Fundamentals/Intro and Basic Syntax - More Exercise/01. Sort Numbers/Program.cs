using System;
using System.Collections.Generic;
//Intro and Basic Syntax - More Exercise
namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            numbers.Add(num1);
            numbers.Add(num2);
            numbers.Add(num3);

            numbers.Sort();
            numbers.Reverse();

            for (int i = 0; i < numbers.Count; i++)
            {

                Console.WriteLine(numbers[i]);
            }
        }
    }
}
