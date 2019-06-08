using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Matching_Brackets
{
   public class MatchingBrackets
    {
        static void Main()
        {
            var secuense = Console.ReadLine();
            var index = new Stack<int>();

            for (int i = 0; i < secuense.Length; i++)
            {
                if (secuense[i] == '(')
                {
                    index.Push(i);
                }
                else if (secuense[i] == ')')
                {
                    int startIndex = index.Pop();
                    var seq = secuense.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(seq);
                }
            }

        }
    }
}
