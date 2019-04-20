using System;
using System.Collections.Generic;
// Data Types and Variables - Lab
namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            string str3 = Console.ReadLine();

            List<string> stringAll = new List<string>();
            stringAll.Add(str3);
            stringAll.Add(str2);
            stringAll.Add(str1);

            Console.Write(string.Join(" ", stringAll));
        }
    }
}
