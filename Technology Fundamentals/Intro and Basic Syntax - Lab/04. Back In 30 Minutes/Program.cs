using System;
//Intro and Basic Syntax - Lab
namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int sumMinutes = minutes + 30;

            if (sumMinutes > 60)
            {
                sumMinutes = sumMinutes - 60;
                hours += 1;
                if (hours > 23)
                {
                    hours = 0;
                }
                if (sumMinutes < 10)
                {
                    Console.WriteLine($"{hours}:0{sumMinutes}");
                }
                else
                {
                    Console.WriteLine($"{hours}:{sumMinutes}");
                }

            }
            else
            {
                Console.WriteLine($"{hours}:{sumMinutes}");

            }

        }
    }
}
