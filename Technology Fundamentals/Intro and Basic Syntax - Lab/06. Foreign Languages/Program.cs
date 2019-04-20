using System;
using System.Runtime.InteropServices;
//Intro and Basic Syntax - Lab
namespace _06._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            string language = string.Empty;

            switch (countryName)
            {
                case "USA":
                case "England":
                    language = "English";
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    language = "Spanish";
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }

            Console.WriteLine($"{language}");
        }
    }
}
