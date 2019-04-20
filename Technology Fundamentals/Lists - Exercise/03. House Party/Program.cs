using System;
using System.Collections.Generic;
//Lists - Exercise
namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            List<string> guestsPartyList = new List<string>();
            for (int i = 0; i < input; i++)
            {
                string command = Console.ReadLine();
                string[] commandLine = command.Split();

                if (commandLine[2] == "going!")
                {
                    bool guestList = false;
                    for (int j = 0; j < guestsPartyList.Count; j++)
                    {
                        if (commandLine[0] == guestsPartyList[j])
                        {
                            Console.WriteLine($"{commandLine[0]} is already in the list!");
                            guestList = true;
                        }
                    }
                    if (!guestList)
                    {
                        guestsPartyList.Add(commandLine[0]);
                    }
                }
                else if (commandLine[2] == "not")
                {
                    bool guestList = false;
                    for (int j = 0; j < guestsPartyList.Count; j++)
                    {
                        if (commandLine[0] == guestsPartyList[j])
                        {
                            guestsPartyList.Remove(commandLine[0]);
                            guestList = true;
                        }
                    }
                    if (!guestList)
                    {
                        Console.WriteLine($"{commandLine[0]} is not in the list!");
                    }
                }
            }
            foreach (var guest in guestsPartyList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
