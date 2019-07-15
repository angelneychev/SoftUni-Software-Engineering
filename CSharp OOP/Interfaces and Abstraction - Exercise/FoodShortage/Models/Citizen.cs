namespace FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using FoodShortage.Contracts;

    public class Citizen : IBirthdayable,IIdentifiable,INameable, IBuyer
    {
        //“Citizen <name> <age> <id> <birthdate>”
        private int age;
        private IBuyer _buyerImplementation;

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

        public int Food { get; private set; }
        public void BuyFood()
        {
           this.Food += 10;
        }
    }

}

