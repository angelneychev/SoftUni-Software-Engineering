using System;

namespace _04._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumberTwo = int.Parse(Console.ReadLine());
            int sumOne = 0;
            int sumTwo = 0;
            int sum = 0;
            for (int i = 1; i <= countNumberTwo; i++)
            {
                if (i == 1)
                {
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    sumOne = number1 + number2;
                }
                else
                {
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    sumTwo = number1 + number2;
                    if (Math.Abs((sumOne - sumTwo)) > sum)
                    {
                        sum = Math.Abs(sumOne - sumTwo);
                    }

                    sumOne = sumTwo;
                }
            }
            if (sum > 0)
            {
                Console.WriteLine($"No, maxdiff={sum}");

            }
            else
            {
                Console.WriteLine($"Yes, value={sumOne}");
            }
        }
    }
}
