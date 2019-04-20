using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            var bandName = new Dictionary<string, int>();
            var memberName = new Dictionary<string, List<string>>();

            while (!bandName.ContainsKey(inputLine))
            {
                //Play; The Beatles; 2584
                if (inputLine.Contains("Play"))
                {
                    string[] command = inputLine.Split("; ");
                    string band = command[1];
                    int time = int.Parse(command[2]);
                    if (!bandName.ContainsKey(band))
                    {
                        bandName.Add(band,time);
                    }
                    else if (bandName.ContainsKey(band))
                    {
                        bandName[band] += time;
                    }
                }
                else if (inputLine.Contains("Add"))
                {
                    string[] command = inputLine.Split("; ");
                    string band = command[1];
                    string[] name = command[2].Split(", ");
                    if (!memberName.ContainsKey(band))
                    {
                        memberName.Add(band,new List<string>());
                    }
                    if (memberName.ContainsKey(band))
                    {
                        for (int i = 0; i < name.Length; i++)
                        {
                            if (!memberName[band].Contains(name[i]))
                            {
                                memberName[band].Add(name[i]);
                            }
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Total time: {bandName.Values.Sum()}");
            foreach (var kvp in bandName.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine($"{inputLine}");
            var print = memberName.Where(x=>x.Key == inputLine);
            //foreach (var item in memberName.Where(x=>x.Key.Equals(inputLine)))
            //{
            //        Console.WriteLine($"{item.Value}"); 
            //}
            foreach (var kvp in memberName.Where(x=>x.Key == inputLine))
            {
                Console.WriteLine(string.Join(Environment.NewLine, kvp.Value.Select(x => $"=> {x}")));
            }
        }
    }
}
