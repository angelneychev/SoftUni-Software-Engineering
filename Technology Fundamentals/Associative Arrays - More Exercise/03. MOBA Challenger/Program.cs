using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            // player.key - (value)- > level.Key - point.Value
            var playersList = new Dictionary<string, Dictionary<string, int>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "Season end")
            {
                if (inputLine.Contains(" -> "))
                {
                    string[] command = inputLine.Split(" -> ").ToArray();
                    string player = command[0];
                    string level = command[1];
                    int point = int.Parse(command[2]);
                    if (!playersList.ContainsKey(player))
                    {
                        playersList.Add(player, new Dictionary<string, int>());
                        playersList[player].Add(level, point);
                    }
                    else if (!playersList[player].ContainsKey(level))
                    {
                        playersList[player].Add(level, point);
                    }

                    if (playersList[player][level] < point)
                    {
                        playersList[player][level] = point;
                    }


                }
                else if (inputLine.Contains(" vs "))
                {
                    string[] command = inputLine.Split(" vs ").ToArray();
                    string firstPlayer = command[0];
                    string secondPlayer = command[1];
                    bool removePlayer = false;
                    if (playersList.ContainsKey(firstPlayer) && playersList.ContainsKey(secondPlayer))
                    {
                        var compareFirstPlayer = playersList[firstPlayer].ToList();
                        var compareSecondPlayer = playersList[secondPlayer].ToList();

                        foreach (var kvp in compareFirstPlayer)
                        {
                       //     Console.WriteLine($"{kvp.Key} - {kvp.Value}");

                            foreach (var item in compareSecondPlayer)
                            {

                                if (kvp.Key == item.Key)
                                {
                                    if (kvp.Value > item.Value)
                                    {
                                        playersList.Remove(secondPlayer);

                                    }
                                    else
                                    {
                                        playersList.Remove(firstPlayer);
                                    }

                                    removePlayer = true;
                          //          Console.WriteLine("BONUS");
                                }

                          //      Console.WriteLine($"{item.Key} = {item.Value}");

                            }
                        }

                    }

                }

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in playersList.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");
                var players = kvp.Value;
                foreach (var player in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($" - {player.Key} <::> {player.Value}");
                }
            }
        }
    }
}
