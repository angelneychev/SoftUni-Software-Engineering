using System;

namespace _05._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            double count200 = 0;
            double count400 = 0;
            double count600 = 0;
            double count800 = 0;
            double count1000 = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());


                if (number < 200)
                {
                    count200++;
                }
                if (number >= 200 && number < 400)
                {
                    count400++;
                }
                if (number >= 400 && number < 600)
                {
                    count600++;
                }
                if (number >= 600 && number < 800)
                {
                    count800++;
                }
                if (number >= 800)
                {
                    count1000++;
                }

            }
            p1 = (count200 / n) * 100;
            p2 = (count400 / n) * 100;
            p3 = (count600 / n) * 100;
            p4 = (count800 / n) * 100;
            p5 = (count1000 / n) * 100;


            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
