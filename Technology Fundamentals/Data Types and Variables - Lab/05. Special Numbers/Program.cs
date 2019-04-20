using System;
// Data Types and Variables - Lab
namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= input; i++)
            {
                sum = (i % 10) + (i / 10);
                switch (sum)
                {
                    case 5:
                    case 7:
                    case 11:
                        Console.WriteLine($"{i} -> True");
                        break;
                    default:
                        Console.WriteLine($"{i} -> False");
                        break;
                }
            }
        }
    }
}
