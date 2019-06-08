using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    public class ReverseStrings
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();

            var stackString = new Stack<char>();

            foreach (char item in inputLine)
            {
                stackString.Push(item);
            }

            Console.WriteLine(string.Join("",stackString));
        }
    }
}
