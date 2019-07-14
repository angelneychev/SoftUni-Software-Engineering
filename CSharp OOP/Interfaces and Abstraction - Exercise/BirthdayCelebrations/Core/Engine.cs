using System.Linq;

namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;

    using BirthdayCelebrations.Contracts;
    using BirthdayCelebrations.Models;

    public class Engine
    {
        private List<IBirthdayable> birthdays;
        private Citizen citizen;
        private Pet pet;

        public Engine()
        {
            this.birthdays = new List<IBirthdayable>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthday = tokens[4];
                    citizen = new Citizen(name,age,id,birthday);
                    birthdays.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthday = tokens[2];
                    pet = new Pet(name,birthday);
                    birthdays.Add(pet);
                }

                command = Console.ReadLine();
            }

            int year = int.Parse(Console.ReadLine());

            foreach (var item in birthdays
                .Where(x => x.Birthdate.Year == year)
                .Select(x => x.Birthdate)
                .ToList())
            {
                Console.WriteLine($"{item:dd/mm/yyyy}");
            }
        }
    }
}
