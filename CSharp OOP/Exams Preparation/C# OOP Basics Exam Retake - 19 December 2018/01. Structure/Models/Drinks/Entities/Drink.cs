using System;
using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Entities
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

        public string Name
        {
            get => this.name;
            private set
            {
//•	Name – string (If the name is null or whitespace throw an ArgumenException with
//message "Name cannot be null or white space!")
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullName);
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get => this.servingSize;
            private set
            {
//•	ServingSize – int (if the serving size is less than or equal to 0, throw an ArgumentException with message
//"Serving size cannot be less or equal to zero")
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeServingSize);
                }

                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
//•	Price – decimal (if the price is less than or equal to 0, throw an ArgumentException with message
//"Price cannot be less or equal to zero")
                if (value <=0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeDrinkPrice);
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;
            private set
            {
//•	Brand -  string (If the brand is null or whitespace thrown ArgumentException with message
//"Brand cannot be null or white space!")
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullBrandName);
                }

                this.brand = value;
            }
        }
//Returns a string with information about each drink. The returned string must be in the following format:
//"{current drink name} {current brand name} - {current serving size}ml - {current price - formatted to the second digit}lv" 

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
