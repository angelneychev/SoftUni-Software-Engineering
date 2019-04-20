using System;
using System.Collections.Generic;
using System.Linq;
//Intro and Basic Syntax - More Exercise
namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToArray().Reverse();

            Console.WriteLine(string.Join("", input));
        }
    }
}
