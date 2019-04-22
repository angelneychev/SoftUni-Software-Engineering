using System;

namespace _06._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int sumPrime = 0;
            int sumNotPrime = 0;

            while (comand != "stop")
            {
                int currentNum = int.Parse(comand);
                int saveNumber = currentNum;
                int b = 0;
                for (int i = 2; i < currentNum; i++)
                {
                    if (currentNum % i == 0)
                    {
                        b = 1;
                        break;
                    }
                }
                if (saveNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (b == 0 && saveNumber != 1)
                {
                    sumPrime += saveNumber;
                }
                else
                {
                    sumNotPrime += saveNumber;
                }
                comand = Console.ReadLine();
                if (comand == "stop")
                {
                    break;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNotPrime}");
        }
    }
}
