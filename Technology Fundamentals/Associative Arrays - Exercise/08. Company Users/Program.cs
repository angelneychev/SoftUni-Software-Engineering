using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(" -> ").ToArray();

            var company = new Dictionary<string, List<string>>();

            while (inputLine[0] != "End")
            {
                string companyName = inputLine[0];
                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                }
                string employeeId = inputLine[1];
                if (!company[companyName].Contains(employeeId))
                {
                    company[companyName].Add(employeeId);
                }
                inputLine = Console.ReadLine().Split(" -> ");
            }
            foreach (var kvp in company.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var emploi in kvp.Value)
                {
                    Console.WriteLine($"-- {emploi}");
                }
            }
        }
    }
}
