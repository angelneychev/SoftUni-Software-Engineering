using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace _01._Club_Party
{// Задача за резервации
    class ClubParty
    {
        static void Main(string[] args)
        {
            int hallsCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Stack<string> simbol = new Stack<string>(input);
            List<string> halsList = new List<string>();
            List<int> addPeople = new List<int>();

            while (simbol.Count > 0)
            {
                string currentSimbol = simbol.Pop();

                bool isNumber = int.TryParse(currentSimbol, out int peopleIn);

                if (!isNumber)
                {
                    halsList.Add(currentSimbol);
                }
                else if (halsList.Count > 0)
                {
                    if (addPeople.Sum() + peopleIn <= hallsCapacity)
                    {
                        addPeople.Add(peopleIn);
                    }
                    else
                    {
                        Console.WriteLine($"{halsList[0]} -> {string.Join(", ", addPeople)}");
                        halsList.RemoveAt(0);
                        addPeople.Clear();

                        if (halsList.Count > 0)
                        {
                            addPeople.Add(peopleIn);
                        }
                    }
                }
            }
        }
    }
}
