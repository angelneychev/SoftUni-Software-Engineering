using System;
using System.Collections.Generic;
using System.Linq;
//Objects and Classes - Lab
namespace TEST
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine()
                .Split();
            var random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                var randomIndex = random.Next(0, words.Length);

                var tempValue = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = tempValue;

            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}