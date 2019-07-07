namespace PersonsInfo
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System;
    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                var firstname = input[0];
                var lastName = input[1];
                var age = input[2];
                var salary = input[3];
                var person = new Person(
                    firstname,
                    lastName,
                    int.Parse(age),
                    decimal.Parse(salary));

                persons.Add(person);
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
