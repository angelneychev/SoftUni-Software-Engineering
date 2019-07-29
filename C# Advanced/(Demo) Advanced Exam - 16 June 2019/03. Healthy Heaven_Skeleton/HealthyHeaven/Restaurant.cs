﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad findSalad = this.data.FirstOrDefault(x => x.Name == name);

            if (findSalad != null) 
            {
                this.data.Remove(findSalad);
                return true;
            }
            return false;
        }

        public Salad GetHealthiestSalad()
        {

            int min = this.data.Min(s => s.GetTotalCalories());
            return this.data.FirstOrDefault(s => s.GetTotalCalories() == min);

        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var salad in data)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
