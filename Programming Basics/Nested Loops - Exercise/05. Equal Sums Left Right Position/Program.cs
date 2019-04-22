using System;

namespace _05._Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int b = 0;
            int c = 0;
            int num = 0;

            for (int i = num1; i <= num2; i++)
            {
                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                num = i;

                for (int w = 1; w <= 5; w++)
                {

                    b = num / 10;
                    c = num % 10;
                    num = b;
                    if (w == 1 || w == 2)
                    {
                        sum1 += c;
                    }
                    else if (w == 4 || w == 5)
                    {
                        sum2 += c;
                    }
                    else if (w == 3)
                    {
                        sum3 += c;
                    }
                }
                if (sum1 > sum2)
                {
                    sum2 += sum3;
                }
                else if (sum1 < sum2)
                {
                    sum1 += sum3;
                }
                if (sum1 == sum2)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
