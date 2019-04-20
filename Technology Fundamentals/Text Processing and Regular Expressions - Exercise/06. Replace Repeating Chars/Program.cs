using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            //aaaaabbbbbcdddeeeedssaa	abcdedsa
           // qqqwerqwecccwd qwerqwecwd

           string inputLine = Console.ReadLine();

           StringBuilder letters = new StringBuilder();

           for (int i = 0; i < inputLine.Length-1; i++)
           {
               if (i==0)
               {
                   letters.Append(inputLine[i]);
               }
               if (inputLine[i] != inputLine[i+1])
               {
                   letters.Append(inputLine[i + 1]);
               }
           }

         //  letters.Append(inputLine[inputLine.Length - 1]);

           Console.WriteLine(letters);
        }
    }
}
