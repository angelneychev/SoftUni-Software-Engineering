using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        //Name – string (If the name is null or whitespace throw an ArgumenException with message "Name cannot be null or white space!")
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                this.name = value;
            }
        }
        //ServingSize – int (if the serving size is less than or equal to 0, throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        public int ServingSize
        {
            get => this.servingSize;
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException ("Serving size cannot be less or equal to zero");
                }
                this.servingSize = value;
            }
            
        }
        //Price – decimal (if the price is less than or equal to 0, throw an ArgumentException with message "Price cannot be less or equal to zero")
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero");
                }
                this.price = value;
            }
        }

        //Brand -  string (If the brand is null or whitespace thrown ArgumentException with message "Brand cannot be null or white space!")
        public string Brand
        {
            get => this.brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }

                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{name} {brand} - {servingSize}ml - {price:f2}lv";
        }
    }
}
