using System;
using System.Collections.Generic;
using System.Linq;
//Arrays - Exercise
namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<int> str1 = new List<int>();
            List<int> str2 = new List<int>();


            for (int i = 1; i <= number; i++)
            {


                List<int> line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();
                int num1 = (int)line[0];
                int num2 = (int)line[1];
                if (i % 2 != 0)
                {
                    str1.Add(num1);
                    str2.Add(num2);
                }
                else
                {
                    str1.Add(num2);
                    str2.Add(num1);
                }
            }

            Console.Write(string.Join(" ", str1));
            Console.WriteLine();
            Console.Write(string.Join(" ", str2));
        }
    }
}
