using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>(); // речник за предмети

            dict["fragments"] = 0;
            dict["shards"] = 0;
            dict["motes"] = 0;

            var junkElements = new Dictionary<string, int>(); // речник за други елементи

            while (true)
            {
                bool haveWiner = false;

                var tokens = Console.ReadLine().ToLower().Split(" ").ToArray();

                for (int i = 0; i < tokens.Length; i+=2)
                {
                    string type = tokens[i + 1]; // пазим името

                    int quantity = int.Parse(tokens[i]); // пазим количестовот

                    if (type == "fragments" || type == "shards" || type == "motes")
                    {
                        // проверяваме дали предмета го има в речника и ако го няма добавяме
                        if (!dict.ContainsKey(type)) 
                        {
                            dict.Add(type,quantity);
                        }
                        else
                        {
                            //ако го има в речника, добавяме само количеството
                            dict[type] += quantity;
                        }
                    }
                    else
                    {
                        // проверяваме дали предмета го има в речника и ако го няма добавяме
                        if (junkElements.ContainsKey(type))
                        {
                            junkElements[type] += quantity;
                        }
                        else
                        {
                            //ако го има в речника, добавяме само количеството
                            junkElements[type] = quantity;
                        }
                    }
                    if (dict["motes"] >= 250 || dict["shards"] >= 250 || dict["fragments"] >= 250)
                    {
                        dict[type] = dict[type] - 250; // остъка от събраните предмети

                        // След това веднага печатаме, това на което отговаря условието.
                        if (type == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                        }
                        else if (type == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                        }
                        else if (type == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                        }

                        haveWiner = true; // стваме, че има предмет събрал нужната сума точки (250 точки)
                        break; // прекъсваме for цикъла

                    }
                }

                if (haveWiner)
                {
                    break;// прекъваме и while цикъла
                }
            }

            foreach (var kvp in dict.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkElements.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} ");
            }
        }
    }
}
