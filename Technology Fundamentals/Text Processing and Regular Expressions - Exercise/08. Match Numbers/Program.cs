using System;
using System.Text.RegularExpressions;

namespace _08._Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(^|(?<=\s))-?\d+(\.[0-9]+)?($|(?=\s))";

            Regex numbers = new Regex(pattern);

            MatchCollection number = numbers.Matches(input);

            Console.WriteLine(string.Join(" ",number));

        }
    }
}
