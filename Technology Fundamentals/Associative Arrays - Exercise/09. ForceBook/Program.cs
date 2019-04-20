using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            var catalog = new Dictionary<string, string>();
            while (inputLine != "Lumpawaroo")
            {

                if (inputLine.Contains(" | "))
                {
                    string[] tokens = inputLine.Split(" | ");
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];
                    if (!catalog.ContainsKey(forceUser))
                    {
                        catalog.Add(forceUser, forceSide);
                    }

                }
                else if (inputLine.Contains(" -> "))
                {
                    string[] tokens = inputLine.Split(" -> ");
                    string forceSide = tokens[1];
                    string forceUser = tokens[0];
                    if (catalog.ContainsKey(forceUser))
                    {
                        if (!catalog.ContainsKey(forceSide))
                        {
                            catalog[forceUser] = forceSide;
                        }
                    }
                    else if (!catalog.ContainsKey(forceUser))
                    {
                        catalog.Add(forceUser, forceSide);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }

                inputLine = Console.ReadLine();
            }

            var currentUser = catalog
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);

            foreach (var kvp in currentUser)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Count()}");

                foreach (var user in kvp.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {user.Key}");
                }
            }
        }
    }
}
