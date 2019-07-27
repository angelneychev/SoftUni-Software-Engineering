using System;
using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
//•	Name – string (If the name is null or whitespace throw an ArgumentException with message
//"Name cannot be null or white space!")
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
                if (value <=0)
                {
//•	ServingSize – int (can’t be less or equal to 0. In these cases, throw an ArgumentException with message
//"Serving size cannot be less or equal to zero")
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
                if (value <= 0)
                {
//•	Price – decimal (can’t be less or equal to 0. In these cases, throw an ArgumentException with message
//"Price cannot be less or equal to zero!")
                    throw new ArgumentException(ExceptionMessages.NegativeFoodPrice);
                }

                this.price = value;
            }
        }
//•	Returns a string with information about each food. The returned string must be in the following format:
//"{current food name}: {current serving size}g - {current price - formatted to the second digit}"
        public override string ToString()
        {

            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
