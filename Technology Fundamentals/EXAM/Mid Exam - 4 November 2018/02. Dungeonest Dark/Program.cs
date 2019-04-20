using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            // rat 10 | bat 20 | potion 10 | rat 10 | chest 100 | boss 70 | chest 1000
            var rooms = Console.ReadLine().Split('|');
            List<string> items = new List<string>();
            List<int> values = new List<int>();
            int health = 100;
            int coins = 0;
            foreach (var a in rooms)
            {
                string[] things = a.Split();
                items.Add(things[0]);
                values.Add(int.Parse(things[1]));
            }

            for (int i = 0; i < rooms.Length; i++)
            {

                if (items[i] == "potion")
                {
                    int healtBonus = values[i];
                    if (health + healtBonus < 100)
                    {
                        health += healtBonus;
                        Console.WriteLine($"You healed for {healtBonus} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (items[i] == "chest")
                {
                    coins += values[i];
                    Console.WriteLine($"You found {values[i]} coins.");
                }
                else
                {
                    health -= values[i];
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {items[i]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {items[i]}.");
                    }
                }

                if (health > 0 && i == rooms.Length - 1)
                {
                    Console.WriteLine($"You've made it!");
                    Console.WriteLine($"Coins: {coins}");
                    Console.WriteLine($"Health: {health}");
                }
            }
        }
    }
}
