using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] textImput = Console.ReadLine()
                .Where(x => x != ' ')
                .ToArray();
            // не бройм спейсвоете и събираме всички стрингове на едно място

            var countChar = new Dictionary<char,int>();

            foreach (var charachater in textImput)
            {
                if (!countChar.ContainsKey(charachater))
                {
                    countChar[charachater] = 0;
                }

                countChar[charachater]++;
            }

            foreach (var kvp in countChar)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
