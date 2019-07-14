﻿namespace BirthdayCelebrations.Models
{
    using System;
    using BirthdayCelebrations.Contracts;

    public class Pet : IBirthdayable
    {

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}
