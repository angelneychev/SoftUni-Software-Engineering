using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Lab
namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < number; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                numbers.Add(inputNumber);
            }

            numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
