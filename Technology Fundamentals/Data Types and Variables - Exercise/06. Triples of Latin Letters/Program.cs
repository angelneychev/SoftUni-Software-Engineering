using System;
// Data Types and Variables - Exercise
namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int smalllatinLatters = int.Parse(Console.ReadLine());

            for (int i = 0; i < smalllatinLatters; i++)
            {
                for (int j = 0; j < smalllatinLatters; j++)
                {
                    for (int k = 0; k < smalllatinLatters; k++)
                    {
                        char firstCahr = (char)('a' + i);
                        char secondChar = (char)('a' + j);
                        char thirdChar = (char)('a' + k);
                        Console.WriteLine($"{firstCahr}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
