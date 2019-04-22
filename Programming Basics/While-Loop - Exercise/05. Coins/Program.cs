using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal input = decimal.Parse(Console.ReadLine());

            long leva = (long)input; // Вземаме стройноста на левовете
            long twoLeva = leva / 2; // Брой монети от 2 лв
            long oneLeva = leva % 2; // Брой монети от 1 лв
            decimal coinsCounter = twoLeva + oneLeva;
            decimal cent = (input * 100) % 100; // Вземаме стройноста на стотинките

            while (cent > 0)
            {
                if (cent >= 50)
                {
                    cent -= 50;
                    coinsCounter++;
                }
                else if (cent < 50 && cent >= 20)
                {
                    cent -= 20;
                    coinsCounter++;
                }
                else if (cent < 20 && cent >= 10)
                {
                    cent -= 10;
                    coinsCounter++;
                }
                else if (cent < 10 && cent >= 5)
                {
                    cent -= 5;
                    coinsCounter++;
                }
                else if (cent < 5 && cent >= 2)
                {
                    cent -= 2;
                    coinsCounter++;
                }
                else if (cent < 2 && cent >= 1)
                {
                    cent -= 10;
                    coinsCounter++;
                }

            }
            Console.WriteLine(coinsCounter);
        }
    }
}
