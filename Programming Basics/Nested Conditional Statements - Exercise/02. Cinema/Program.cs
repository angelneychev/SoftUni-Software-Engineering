using System;

namespace _02._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            var row = int.Parse(Console.ReadLine());
            var colunms = int.Parse(Console.ReadLine());

            int capacity = row * colunms;
            double income = 0;

            switch (type)
            {
                case "premiere":
                    income = capacity * 12.00;
                    break;
                case "normal":
                    income = capacity * 7.50;
                    break;
                case "discount":
                    income = capacity * 5;
                    break;
            }
            Console.WriteLine($"{income:F2}");
        }
    }
}
