using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb= new StringBuilder();

            foreach (var symvbol in input)
            {
                char encriptedSymbol = (char)(symvbol + 3);

                sb.Append(encriptedSymbol);
            }

            Console.WriteLine(sb);
        }
    }
}
