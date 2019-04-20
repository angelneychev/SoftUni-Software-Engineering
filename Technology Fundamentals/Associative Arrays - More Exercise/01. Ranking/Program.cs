using System;
using System.Collections.Generic;
using System.Linq;



namespace _01._Ranking
{
    class Program
    {
        static void Main()
        {
            var exams = new Dictionary<string, string>();
            var candidate = new Dictionary<string,Dictionary<string,int>>();
            

            string inputLine = Console.ReadLine();

            while (inputLine != "end of contests" || inputLine.Contains(":"))
            {
                string[] tokens = inputLine.Split(":");
                string contest = tokens[0];
                if (!exams.ContainsKey(contest))
                {
                    string password = tokens[1];

                    exams.Add(contest, password);
                }

                inputLine = Console.ReadLine();
            }
            inputLine = Console.ReadLine();
            while (inputLine != "end of submissions" || inputLine.Contains("=>"))
            {
                string[] tokens = inputLine.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (exams.ContainsKey(contest) && exams.ContainsValue(password))
                {
                    if (!candidate.ContainsKey(username))
                    {
                        candidate.Add(username, new Dictionary<string, int>());
                        candidate[username].Add(contest,points);
                    }
                    else if (!candidate[username].ContainsKey(contest))
                    {
                        candidate[username].Add(contest,points);
                    }
                    if (candidate[username][contest] < points)
                    {
                        candidate[username][contest] = points;
                    }
                }

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in candidate.Take(1))
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            }

            Console.WriteLine("Ranking: ");
            foreach (var kvp in candidate.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                var contest = kvp.Value;
                foreach (var exam in contest.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {exam.Key} -> {exam.Value}");
                }
            }

        }
    }
}
