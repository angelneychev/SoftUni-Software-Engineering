namespace BirthdayCelebrations.Models
{
    using System;
    using BirthdayCelebrations.Contracts;

    public class Citizen : IBirthdayable
    {
        //“Citizen <name> <age> <id> <birthdate>”
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Id { get; private set; }
    }
}
