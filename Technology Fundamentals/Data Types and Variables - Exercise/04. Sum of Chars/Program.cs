using System;
// Data Types and Variables - Exercise
namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberChar = int.Parse(Console.ReadLine());
            int totalSum = 0;
            for (int i = 0; i < numberChar; i++)
            {
                char englishAlphabet = char.Parse(Console.ReadLine());
                totalSum += englishAlphabet;

            }

            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
