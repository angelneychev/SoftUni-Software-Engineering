using System;

namespace _06._Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double count200 = 0;
            double count400 = 0;
            double count600 = 0;


            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());


                if (number % 2 == 0)
                {
                    count200++;
                }
                if (number % 3 == 0)
                {
                    count400++;
                }
                if (number % 4 == 0)
                {
                    count600++;
                }

            }
            p1 = (count200 / n) * 100;
            p2 = (count400 / n) * 100;
            p3 = (count600 / n) * 100;


            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
