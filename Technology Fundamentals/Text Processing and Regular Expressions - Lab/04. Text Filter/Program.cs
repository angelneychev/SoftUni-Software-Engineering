using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(new []{',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var word in words)
            {
                var replasment = new string('*', word.Length);

                text = text.Replace(word, replasment);
            }

            Console.WriteLine(text);
        }
    }
}
