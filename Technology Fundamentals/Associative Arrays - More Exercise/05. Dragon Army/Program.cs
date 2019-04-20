using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._Dragon_Army
{
    class Program
    {
        static void Main()
        {


            var dragons = new Dictionary<string, Dictionary<string, List<int>>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string[] inputLine = Console.ReadLine().Split().ToArray();
                string type = inputLine[0];
                string name = inputLine[1];
                string damage = inputLine[2];
                string health = inputLine[3];
                string armor = inputLine[4];
                //health 250, damage 45, and armor 10. Missing stat will be marked by null.
                //Gold Traxx 500 null 0
                if (damage == "null")
                {
                    damage = "45";
                }

                if (health == "null")
                {
                    health = "250";
                }

                if (armor == "null")
                {
                    armor = "10";
                }
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type,new Dictionary<string, List<int>>());
                    dragons[type].Add(name,new List<int>());
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, new List<int>());
                    }
                }
                dragons[type][name].Add(int.Parse(damage));
                dragons[type][name].Add(int.Parse(health));
                dragons[type][name].Add(int.Parse(armor));
            }
            //  {type} {name} {damage} {health} {armor}
            //  Red Bazgargal 100 2500 25
            //  Red::(160.00/2350.00/30.00)
            // -Bazgargal->damage: 100, health: 2500, armor: 25

            foreach (var dragon in dragons.OrderBy(x=>x.Key))
            {
                var currentType = dragon.Value;

                var temp = dragon.Value.ToList();
                foreach (var item in temp)
                {
                    var dm = item.Value[0];
                    Console.WriteLine(dm);
                }

                //Console.WriteLine($"{dragon.Key} - {dragon.Value.Values.OrderBy(x=>x.Average())}");
                // Console.WriteLine($"{dragons}::(");
                //foreach (var typeDragon in currentDragon)
                //{
                //    Console.WriteLine($"{typeDragon}");
                Console.WriteLine($"{dragon.Key}");
                foreach (var kvp in currentType.OrderByDescending(x => x.Value.Average()))
                    {
                    Console.WriteLine($"-{kvp.Key} -> damage: {kvp.Value[0]}, " +
                                          $"health: {kvp.Value[1]}, armor: {kvp.Value[2]}");
                    }
                //}

            }

        }
    }
}
