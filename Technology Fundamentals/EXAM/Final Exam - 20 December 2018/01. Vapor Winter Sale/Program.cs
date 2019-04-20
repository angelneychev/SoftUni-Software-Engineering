using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main()
        {
            var gamePrice = new Dictionary<string, double>();
            var gameDls = new Dictionary<string,string>();
            string inputLine = Console.ReadLine();
            string[] commandLine = inputLine.Split(", ");

            for (int i = 0; i < commandLine.Length; i++)
            {
                if (commandLine[i].Contains("-"))
                {
                    string[] command = commandLine[i].Split("-");
                    string game = command[0];
                    double price = double.Parse(command[1]);
                    if (!gamePrice.ContainsKey(game))
                    {
                        gamePrice.Add(game,price);
                    }
                   // gamePrice[game] /= 1.2;
                }
                else if (commandLine[i].Contains(":"))
                {
                    string[] command = commandLine[i].Split(":");
                    string game = command[0];
                    string dls = command[1];
                    if (!gameDls.ContainsKey(game) && gamePrice.ContainsKey(game))
                    {
                        gameDls.Add(game, dls);
                         //  gamePrice[game] *=1.2;
                        // var currentPrice = gamePrice.Where(x =>x.Key == game);
                        gamePrice[game] *=1.2;
                       // gamePrice[game] -= gamePrice[game] * 0.5;
                    }
                    {
                      //  gamePrice[game] -= gamePrice[game] * 0.2;
                    }
                }
            }
            var prices = new Dictionary<string, double>();
            var dlss = new Dictionary<string, string>();
            foreach (var d in gamePrice)
            {
                prices.Add(d.Key, d.Value);
            }
            foreach (var dl in gameDls)
            {
                dlss.Add(dl.Key, dl.Value);
            }

            var currentPrice = dlss.Keys;

            foreach (var price in prices)
            {
                if (currentPrice.Contains(price.Key))
                {
                    gamePrice[price.Key] = price.Value - (price.Value * 0.5);
                }
                else
                {
                    gamePrice[price.Key] = price.Value - (price.Value * 0.2);
                }
                
            }

            foreach (var kvp in gamePrice.OrderBy(x=>x.Value))
            {
                if (currentPrice.Contains(kvp.Key))
                {
                    foreach (var gameDl in gameDls.Where(x=>x.Key == kvp.Key))
                    {
                        Console.WriteLine($"{gameDl.Key} - {gameDl.Value} - {kvp.Value:f2}" );
                    }
                }
               
            }
            foreach (var kvp in gamePrice.OrderByDescending(x=>x.Value))
            {
                if (!currentPrice.Contains(kvp.Key))
                {

                        Console.WriteLine($"{kvp.Key} - {kvp.Value:f2}");
 
                }

            }
        }
    }
}
