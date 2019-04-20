using System;
using System.Collections.Generic;
using System.Linq;


namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var course = new Dictionary<string, List<string>>();
            string[] inputLine = Console.ReadLine().Split(" : ").ToArray();

            while (inputLine[0] != "end")
            {
                string courseName = inputLine[0];
                string studentName = inputLine[1];

                if (!course.ContainsKey(courseName))
                {
                    course.Add(courseName,new List<string>());
                    //course[courseName].Add(studentName);
                }
                course[courseName].Add(studentName);

                inputLine = Console.ReadLine().Split(" : ");

            }

            foreach (var kvp in course.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var name in kvp.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {string.Join("",name)}");

                }
                
            }
        }

    }
}
