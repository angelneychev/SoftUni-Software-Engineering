﻿using System;
using System.Linq.Expressions;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods
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
        //Name – string (If the name is null or whitespace throw an ArgumentException with message "Name cannot be null or white space!")
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                this.name = value;
            }
        }
        //ServingSize – int (can’t be less or equal to 0. In these cases, throw an ArgumentException with message "Serving size cannot be less or equal to zero")
        public int ServingSize
        {
            get => this.servingSize;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }

                this.servingSize = value;
            }
        }
        //Price – decimal (can’t be less or equal to 0. In these cases, throw an ArgumentException with message "Price cannot be less or equal to zero!")
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }
        
        //"{current food name}: {current serving size}g - {current price - formatted to the second digit}"
        public override string ToString()
        {
            return $"{name}: {servingSize}g - {price:f2}";
        }

         
    }
}
