using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var registerUsername = new Dictionary<string,string>();
            int numberCommand = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= numberCommand; i++)
            {
                string[] inpitLine = Console.ReadLine().Split(" ").ToArray();

                string command = inpitLine[0];
                string username = inpitLine[1];

                if (command == "register")
                {
                    string licensePlateNumber = inpitLine[2];
                    if (!registerUsername.ContainsKey(username))
                    {
                        registerUsername.Add(username,licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (command == "unregister")
                {
                    if (registerUsername.ContainsKey(username))
                    {
                        registerUsername.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var kvp in registerUsername)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
