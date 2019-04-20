using System;
using System.Collections.Generic;
using System.Linq;


namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            var shop =new Dictionary<string, List<string>>();

            while (inputLine != "END")
            {
                string[] command = inputLine.Split("->");
               // string shopName = command[1];
                if (inputLine.Contains("Add"))
                {
                    string shopName = command[1];
                    string allArticul = command[2];
                    if (!shop.ContainsKey(shopName))
                    {
                        shop.Add(shopName, new List<string>());
                    }
                    if (allArticul.Contains(","))
                        {
                            string[] tokkens = allArticul.Split(",");
                            for (int i = 0; i < tokkens.Length; i++)
                            {
                                shop[shopName].Add(tokkens[i]);
                            }
                        }
                    else
                        {
                            shop[shopName].Add(allArticul);
                        }

                }
                else if (inputLine.Contains("Remove"))
                {
                   string shopName = command[1];
                   if (shop.ContainsKey(shopName))
                   {
                       shop.Remove(shopName);
                   }
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");
            foreach (var kvp in shop.OrderByDescending(x=>x.Key).OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
