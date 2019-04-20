using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordsLowerCase = word.ToLower();
                if (!counts.ContainsKey(wordsLowerCase))
                {
                    counts.Add(wordsLowerCase, 1);
                }
                else
                {
                    counts[wordsLowerCase]++;
                }
            }
            foreach (var count in counts)
            {
                if (count.Value % 2 == 1)
                {
                    Console.Write(count.Key + " ");
                }

            }
        }
    }
}
