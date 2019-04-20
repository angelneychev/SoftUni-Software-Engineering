using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {

            var studantAndpoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input=Console.ReadLine()) != "exam finished")
            {
                //Pesho-Java-84
                string[] inputLine = input.Split("-").ToArray();

                string name = inputLine[0];

                if (inputLine[1] == "banned")
                {
                    studantAndpoints.Remove(name);
                }
                else
                {
                    string language = inputLine[1];
                    int points = int.Parse(inputLine[2]);
                    if (!studantAndpoints.ContainsKey(name))
                    {
                        studantAndpoints[name] = points;
                    }
                    else if (points > studantAndpoints[name])
                    {
                        studantAndpoints[name] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }

                    submissions[language]++;
                }

            }

            Console.WriteLine("Results:");
            foreach (var kvp in studantAndpoints
                .OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
