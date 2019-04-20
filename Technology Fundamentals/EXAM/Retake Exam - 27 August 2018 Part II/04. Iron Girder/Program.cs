using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            var townTime = new Dictionary<string,int>();
            var countPassengerse = new Dictionary<string, int>();

            while (inputLine != "Slide rule")
            {
                string[] tokens = inputLine.Split(new string[] {":", "->"}, StringSplitOptions.RemoveEmptyEntries);
                string townName = tokens[0];
                string times = tokens[1];
                int passengersCount = int.Parse(tokens[2]);

                if (times != "ambush")
                {
                    if (!townTime.ContainsKey(townName))
                    {
                        townTime.Add(townName,int.Parse(times));
                        countPassengerse.Add(townName,passengersCount);
                    }
                    else
                    {
                        int tempTime = int.Parse(times);
                        var townTimeValue = townTime.Select(x=>x.Value > tempTime);
                        if (townTime[townName] > tempTime || townTime[townName] ==0)
                        {
                            townTime[townName] = tempTime;
                        }
                        countPassengerse[townName] += passengersCount;
                    }
                }
                else 
                {
                    if (townTime.ContainsKey(townName))
                    {
                        townTime[townName] = 0;
                        countPassengerse[townName] -= passengersCount;
                    }
                }
                inputLine = Console.ReadLine();
            }

            foreach (var town in townTime.OrderBy(x => x.Value).ThenBy(x=>x.Key))
            {
                string towns = town.Key;
                if (townTime[towns] == 0 || countPassengerse[towns] ==0)
                {
                    continue;
                }
                Console.WriteLine($"{town.Key} -> Time: {town.Value} -> Passengers: {countPassengerse[towns]}");
            }
                
        }
    }
}
