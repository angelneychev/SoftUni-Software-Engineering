using System;
// Data Types and Variables - Lab
namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = string.Empty;
            b = a.ToLower();
            if (a == b)
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
