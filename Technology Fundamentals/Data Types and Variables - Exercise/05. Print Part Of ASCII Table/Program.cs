using System;
// Data Types and Variables - Exercise
namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCharNumber = int.Parse(Console.ReadLine());
            int secondCharNumber = int.Parse(Console.ReadLine());

            for (int i = firstCharNumber; i <= secondCharNumber; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
