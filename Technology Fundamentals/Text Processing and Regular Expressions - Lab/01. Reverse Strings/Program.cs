using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string words = string.Empty;
                for (int i = inputLine.Length -1; i >=0 ; i--)
                {
                    words += inputLine[i];
                }
                Console.WriteLine($"{inputLine} = {words}");
                inputLine = Console.ReadLine();

                
            }
        }
    }
}
