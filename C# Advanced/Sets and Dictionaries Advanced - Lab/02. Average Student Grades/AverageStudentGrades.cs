using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace _02._Average_Student_Grades
{
   public class AverageStudentGrades
    {
        static void Main()
        {
            
            Dictionary<string,List<double>> grades = new Dictionary<string, List<double>>();
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string[] tokkens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string student = tokkens[0];
                double grade = (double.Parse(tokkens[1]));
               

                if (!grades.ContainsKey(student))
                {
                    grades.Add(student, new List<double>());
                }
                grades[student].Add(grade);
            }

            foreach (var pair in grades)
            {
                var name = pair.Key;
                var studentGrades = pair.Value;
                var average = studentGrades.Average();
                Console.Write($"{name} -> ");
                foreach (var grade in studentGrades)
                    Console.Write($"{grade:f2} ");
                Console.WriteLine($"(avg: {average:f2})");
            }

        }
    }
}
