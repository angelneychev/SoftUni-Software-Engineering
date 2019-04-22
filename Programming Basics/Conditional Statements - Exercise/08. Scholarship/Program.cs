using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double scholarship = 0;
            double scholarship1 = 0;
            if (average <= 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income < minSalary && average > 4.50 && average < 5.50)
            {
                scholarship = minSalary * 0.35;
                Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(scholarship));
            }
            else if (income < minSalary && average >= 5.50)
            {
                scholarship = minSalary * 0.35;
                scholarship1 = average * 25;
                if (scholarship > scholarship1)
                {
                    Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(scholarship));
                }
                else
                {
                    Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(scholarship1));
                }
            }
            else if (income >= minSalary && average >= 5.50)
            {
                scholarship1 = average * 25;
                Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(scholarship1));
            }
            else if (income >= minSalary && average >= 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
