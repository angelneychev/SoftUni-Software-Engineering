using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace _07._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(\d{2})([-.\/])([A-z][a-z]{2})(\2)(\d{4})\b";
             
            Regex regex = new Regex(pattern);
            MatchCollection options = regex.Matches(input);

            foreach (Match match in options)
            {
                Console.WriteLine($"Day: {match.Groups[1].Value}, Month: {match.Groups[3].Value}, Year: {match.Groups[5].Value}");
            }
        }
    }
}
