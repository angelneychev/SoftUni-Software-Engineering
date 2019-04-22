using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int negativRating = int.Parse(Console.ReadLine());
            int count = 0;
            double sumRating = 0.0;
            int rating = 0;
            int countNegativ = 0;
            string lastTaskName = string.Empty;

            while (true)
            {
                string nameTask = Console.ReadLine();
                if (nameTask != "Enough")
                {
                    rating = int.Parse(Console.ReadLine());
                    count++;
                }
                else
                {
                    rating = 0;
                }
                sumRating += rating;
                double avaerigeRating = sumRating / count;
                if (nameTask == "Enough")
                {
                    avaerigeRating = sumRating / count;
                    Console.WriteLine($"Average score: {avaerigeRating:F2}");
                    Console.WriteLine($"Number of problems: {count}");
                    Console.WriteLine($"Last problem: {lastTaskName}");
                    break;
                }
                lastTaskName = nameTask;
                if (rating <= 4)
                {
                    countNegativ++;
                }
                // int sum = countNegativ - negativRating;
                if ((countNegativ - negativRating) == 0)
                {
                    Console.WriteLine($"You need a break, {countNegativ} poor grades.");
                    break;
                }
            }
        }
    }
}
