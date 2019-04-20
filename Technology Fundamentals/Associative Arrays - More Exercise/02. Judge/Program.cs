using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var constest = new Dictionary<string, Dictionary<string, int>>();
            var pointTotal = new Dictionary<string, int>();

            string inputLine = Console.ReadLine();

            while (inputLine != "no more time")
            {
                //Pesho -> Algo -> 400
                string[] tokens = inputLine.Split(" -> ");  

                string username = tokens[0];
                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!constest.ContainsKey(language))
                {
                    constest.Add(language, new Dictionary<string, int>());
                    constest[language][username] = points;
                }
                else
                {
                    if (!constest[language].ContainsKey(username))
                    {
                        constest[language][username] = points;

                    }
                    else
                    {
                        if (constest[language][username] < points)
                        {
                            constest[language][username] = points;
                        }
                    }

                }


                //else if (!constest[language].ContainsKey(username))
                //{
                //    constest[language].Add(username, points);

                //}
                //if (constest[language][username] < points)
                //{
                //    constest[language][username] = points;
                //}

                //if (to)
                //{
                //    pointTotal.Add(username,new Dictionary<string, int>());
                //    pointTotal[username][language] = points;
                //}
                //else if (!pointTotal[username].ContainsKey(language))
                //{
                //    pointTotal[username].Add(language,points);
                //}

                //else if (pointTotal[username][language] < points)
                //{
                //    pointTotal[username][language] = points;
                //}

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in constest.OrderByDescending(x => x.Value.Count))
            {
                int count = 0;
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");

                var users = kvp.Value;

                foreach (var user in users.OrderByDescending(x => x.Value))
                {
                    count++;
                    Console.WriteLine($"{count}. {user.Key} <::> {user.Value}");
                }
            }

            int counts = 0;

            
            Console.WriteLine("Individual standings:");
            foreach (var contests in constest)
            {
                foreach (var name in contests.Value)
                {
                    if (!pointTotal.ContainsKey(contests.Key))
                    {
                        pointTotal[name.Key] = name.Value;
                    }
                    else
                    {
                        pointTotal[name.Key] += name.Value;
                    }
                }
                
            }
            foreach (var name in pointTotal.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                counts++;
                Console.WriteLine($"{counts}. {name.Key} -> {name.Value}");
            }
        }
    }
}