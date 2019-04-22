using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;

            for (int i = 1; i <= count; i++)

            {
                int newNumber = int.Parse(Console.ReadLine());

                if (max < newNumber)
                {
                    max = newNumber;
                }
                sum += newNumber;
            }
            int endSum = sum - max;
            int diffSum = max - endSum;
            if (endSum == max)
            {
                Console.WriteLine($"Yes Sum = {max}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(diffSum)}");
            }
        }
    }
}
