using System;
using System.Reflection.Metadata;
// Data Types and Variables - Lab
namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine(firstName + delimiter + lastName);
        }
    }
}
