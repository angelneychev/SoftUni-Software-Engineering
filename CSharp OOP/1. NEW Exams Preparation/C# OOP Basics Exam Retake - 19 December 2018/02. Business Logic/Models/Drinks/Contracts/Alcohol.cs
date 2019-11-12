using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 1.5m;
        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
