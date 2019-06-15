using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._CitiesContinentCountry
{
   public class CitiesByContinentAndCountry
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var dictionaryData = new Dictionary<string,Dictionary<string,List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                //continents, countries and their cities
                var continents = input[0];
                var countries = input[1];
                var cities = input[2];
                if (!dictionaryData.ContainsKey(continents))
                {
                    dictionaryData[continents]=new Dictionary<string,List<string>>();
                    
                }

                if (!dictionaryData[continents].ContainsKey(countries))
                {
                    dictionaryData[continents][countries] = new List<string>();
                }

                dictionaryData[continents][countries].Add(cities);

            }

            foreach (var kvp in dictionaryData)
            {
                var continents = kvp.Key;
                var countries = kvp.Value;
                Console.WriteLine($"{kvp.Key}:");
                foreach (var countryKvp in countries)
                {
                    Console.WriteLine($" {countryKvp.Key} -> {string.Join(", ",countryKvp.Value)}");
                }

            }
        }
    }
}
