using System;
//Intro and Basic Syntax - Exercise
namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            string numbers = string.Empty;
            int sum = 0;

            for (int i = startNumber; i <= endNumber; i++)
            {
                sum += i;
                numbers = (numbers + i) + " ";
            }

            Console.WriteLine(numbers);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
