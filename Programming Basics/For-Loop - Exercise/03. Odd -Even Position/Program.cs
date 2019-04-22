using System;

namespace _03._Odd__Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double evenSum = 0;
            double oddSum = 0;
            double oddMin = int.MaxValue;
            double evenMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenMax = int.MinValue;
            int count = 0;

            for (int i = 1; i <= num; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                count++;
                if (i % 2 == 0)
                {
                    evenSum += currentNum;
                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                    }
                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                    }

                }
                else
                {
                    oddSum += currentNum;
                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                    }
                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                    }
                }

            }
            Console.WriteLine($"OddSum={oddSum}");

            if (oddMin == int.MaxValue)
            {
                Console.WriteLine("OddMin=No");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin}");
            }
            if (oddMax == int.MinValue)
            {
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax}");
            }

            Console.WriteLine($"EvenMin={evenSum}");

            if (evenMin == int.MaxValue)
            {
                Console.WriteLine("EvenMin=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin}");
            }
            if (evenMax == int.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax}");
            }

        }
    }
}
