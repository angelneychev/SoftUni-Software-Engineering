using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MeTube_Statistics
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            var dict = new Dictionary<string, int>();
            var dict2 = new Dictionary<string,int>();
            bool sort = true;

            while (inputLine != "by likes" || inputLine != "by views")
            {
                if (inputLine == "by likes")
                {
                    sort = true;
                    break;
                }
                else if (inputLine == "by views")
                {
                    sort = false;
                    break;
                }
                if (inputLine.Contains("-"))
                {
                    string[] command = inputLine.Split("-");
                    if (!dict.ContainsKey(command[0]))
                    {
                        dict.Add(command[0], int.Parse(command[1]));
                        dict2[command[0]] = 0;
                    }
                    else if (dict.ContainsKey(command[0]))
                    {
                        dict[command[0]] += int.Parse(command[1]);
                    }
                }
                else if (inputLine != ":")
                {
                    string[] command = inputLine.Split(":");
                    if (command[0] == "like" && dict2.ContainsKey(command[1]))
                    {
                        dict2[command[1]] += 1;
                    }
                    else if (command[0] == "dislike" && dict2.ContainsKey(command[1]))
                    {
                        dict2[command[1]] -= 1;
                        if (dict2[command[1]] <0)
                        {
                            dict2[command[1]] = 0;
                        }
                    }
                }
                inputLine = Console.ReadLine();
            }

            if (sort)
            {
                foreach (var kvp in dict2.OrderByDescending(x => x.Value))
                {
                    foreach (var count in dict.Where(x => x.Key == kvp.Key))
                    {
                        Console.WriteLine($"{count.Key} - {count.Value} views - {kvp.Value} likes");
                    }
                }
            }
            else
            {
                foreach (var kvp in dict.OrderByDescending(x => x.Value))
                {
                    foreach (var count in dict2.Where(x => x.Key == kvp.Key))
                    {
                        Console.WriteLine($"{count.Key} - {kvp.Value} views - {count.Value} likes");
                    }
                }
            }

        }
    }
}