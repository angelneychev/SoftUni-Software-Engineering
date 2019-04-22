using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {

            string searchBooks = Console.ReadLine();
            int countBooks = int.Parse(Console.ReadLine());
            int count = 0;


            while (true)
            {
                string nalBooks = Console.ReadLine();
                count++;
                if (count > countBooks)
                {
                    count--;
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {count} books.");
                    break;
                }

                if (searchBooks == nalBooks)
                {
                    count--;
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
            }
        }
    }
}
