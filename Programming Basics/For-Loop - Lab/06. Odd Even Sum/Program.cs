using System;

namespace _06._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += newNum;
                }
                else
                {
                    oddSum += newNum;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine($"Yes Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(evenSum - oddSum)}");
            }
        }
    }
}
