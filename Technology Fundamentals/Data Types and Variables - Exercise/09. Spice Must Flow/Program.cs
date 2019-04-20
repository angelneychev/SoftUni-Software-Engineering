using System;
// Data Types and Variables - Exercise
namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int countDay = 0;

            while (input >= 100)
            {
                int day = input - 26;
                totalAmount = totalAmount + day;
                input = input - 10;
                countDay++;
            }
            if (totalAmount < 26)
            {
                totalAmount = 0;
            }
            else
            {
                totalAmount = totalAmount - 26;
            }
            Console.WriteLine(countDay);
            Console.WriteLine(totalAmount);
        }
    }
}
