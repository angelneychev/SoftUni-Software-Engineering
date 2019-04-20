using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(word.ToLower()))
            {
                text = text.Replace(word.ToLower(), string.Empty);
            }
            

            Console.WriteLine(text);

        }
    }
}
