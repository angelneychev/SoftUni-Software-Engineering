using System;
//Programming Fundamentals - Retake Exam - 10 January 2019 Part I
namespace _01._Santa_s_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int batches = int.Parse(Console.ReadLine());
            int box = 0;

            for (int i = 1; i <= batches; i++)
            {
                int flourGrams = int.Parse(Console.ReadLine());
                int sugarGrams = int.Parse(Console.ReadLine());
                int cоcаoGrams = int.Parse(Console.ReadLine());

                int flourCups = flourGrams / 140;
                int bigSpoon = sugarGrams / 20;
                int smallSpoon = cоcаoGrams / 10;

                if (flourCups <= 0 || smallSpoon <= 0 || bigSpoon <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                    continue;
                }

                int minCookies = Math.Min(flourCups, Math.Min(smallSpoon, bigSpoon));

                int cookies = ((140 + 10 + 20) * minCookies) / 25;

                int theBox = cookies / 5;
                box += theBox;
                Console.WriteLine($"Boxes of cookies: {theBox}");
            }
            Console.WriteLine($"Total boxes: {box}");
        }
    }
}
