using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double timeOneMeters = double.Parse(Console.ReadLine());

            double swimTime = length * timeOneMeters;
            double slowTime = Math.Floor((length / 15)) * 12.5;
            double allTime = swimTime + slowTime;

            if (worldRecord <= allTime)
            {
                Console.WriteLine($"No, he failed! He was {(allTime - worldRecord):F2} seconds slower.");

            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {(allTime):F2} seconds.");
            }
        }
    }
}
