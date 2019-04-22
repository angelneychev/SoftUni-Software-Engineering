using System;

namespace _06._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            int currentClass = 1;
            double allGrade = 0;

            while (currentClass <= 12)
            {
                if (grade >= 4.00)
                {
                    allGrade += grade;
                    currentClass++;
                }
                if (currentClass < 13)
                {
                    grade = double.Parse(Console.ReadLine());
                }
            }
            double averange = allGrade / 12;
            Console.WriteLine($"{student} graduated. Average grade: {averange:F2}");
        }
    }
}
