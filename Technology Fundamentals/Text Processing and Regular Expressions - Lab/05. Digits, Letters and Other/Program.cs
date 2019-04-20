using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            //Agd#53Dfg^&4F53

            string words = Console.ReadLine();

            var digits = new List<char>();
            var letters = new List<char>();
            var symbols = new List<char>();

            foreach (var word in words)
            {
                if (char.IsDigit(word))
                {
                    Console.Write(word);
                }
            }

            Console.WriteLine();
            foreach (var word in words)
            {
                if (char.IsLetter(word))
                {
                    Console.Write(word);
                }
            }

            Console.WriteLine();
            foreach (var word in words)
            {
                if (!(char.IsDigit(word) || char.IsLetter(word)))
                {
                    Console.Write(word);
                }
            }
            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (char.IsDigit(words[i]))
            //    {
            //        digits.Add(words[i]);
            //    }
            //    else if (char.IsLetter(words[i]))
            //    {
            //        letters.Add(words[i]);
            //    }
            //    else
            //    {
            //        symbols.Add(words[i]);
            //    }
            //}

            //Console.WriteLine(string.Join("",digits));
            //Console.WriteLine(string.Join("",letters));
            //Console.WriteLine(string.Join("",symbols));

        }
    }
}
