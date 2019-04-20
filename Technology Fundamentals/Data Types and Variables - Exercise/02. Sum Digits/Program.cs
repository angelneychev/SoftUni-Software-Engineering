using System;
// Data Types and Variables - Exercise
namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            string lent = number.ToString();
            int a = number;
            int sum = 0;
            for (int i = 0; i < lent.Length; i++)
            {
                int b = number % 10;
                number = number / 10;
                sum += b;

            }

            Console.WriteLine(sum);


        }
    }
}
