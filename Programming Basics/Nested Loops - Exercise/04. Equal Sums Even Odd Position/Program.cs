using System;

namespace _04._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            //string numInString = number.ToString();
            //  int count = numInString.Length;
            //Console.WriteLine(number);
            //Console.WriteLine(count);
            int b = 0;
            int c = 0;
            int num = 0;

            for (int i = num1; i <= num2; i++)
            {
                int sum1 = 0;
                int sum2 = 0;
                num = i;

                for (int w = 1; w <= 6; w++)
                {

                    b = num / 10;
                    c = num % 10;
                    num = b;
                    if (w % 2 == 0)
                    {
                        sum1 += c;
                    }
                    else
                    {
                        sum2 += c;
                    }
                }
                if ((sum1 > 0 && sum2 > 0) && (sum1 == sum2))
                {
                    Console.Write($"{i} ");
                }

            }
        }
    }
}
