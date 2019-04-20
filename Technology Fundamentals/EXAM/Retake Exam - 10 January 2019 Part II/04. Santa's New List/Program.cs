using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Santa_s_New_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = new Dictionary<string, int>();
            var toy = new Dictionary<string, int>();

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] tokens = inputLine.Split("->");
                if (tokens[0] == "Remove")
                {
                    children.Remove(tokens[1]);
                }
                else
                {
                    string childName = tokens[0];
                    string typeOfPresent = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    if (!children.ContainsKey(childName))
                    {
                        children.Add(childName, amount);
                    }
                    else //if (children.ContainsKey(childName))
                    {
                        children[childName] += amount;
                    }

                    if (!toy.ContainsKey(typeOfPresent))
                    {
                        toy.Add(typeOfPresent, amount);
                    }
                    else //if (toy.ContainsKey(typeOfPresent))
                    {
                        toy[typeOfPresent] += amount;
                    }
                }
                inputLine = Console.ReadLine();
            }

            Console.WriteLine("Children:");
            foreach (var kvp in children.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine("Presents:");
            foreach (var kvp in toy)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
