using System;

namespace _07._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judge = int.Parse(Console.ReadLine());
            // double averageRating = 0;
            double averageAll = 0;
            int count = 0;
            while (true)
            {
                string presentation = Console.ReadLine();

                if (presentation == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {(averageAll / count):F2}.");
                    break;
                }

                double averageRating = 0;
                for (int k = 0; k < judge; k++)
                {
                    double evaluation = double.Parse(Console.ReadLine());
                    count++;
                    averageRating += evaluation;
                    averageAll += evaluation;

                }
                Console.WriteLine($"{presentation} - {(averageRating / judge):F2}.");
            }
        }
    }
}
