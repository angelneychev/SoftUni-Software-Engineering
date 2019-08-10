using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private IList<IFood> foodOrders;
        private IList<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        protected Table(int tableNumber, int capacity, decimal price)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.pricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople =0;
            this.IsReserved = false;
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }
        public int TableNumber { get; }

        public bool IsReserved { get; private set; }

        public decimal Price 
            => this.foodOrders.Sum(x => x.Price) 
               + this.drinkOrders.Sum(x => x.Price) 
               + this.pricePerPerson * this.numberOfPeople;


        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }
        public decimal GetBill()
        {
            return this.Price;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {capacity}")
                .AppendLine($"Price per Person: {pricePerPerson:F2}");

            return result.ToString().TrimEnd();
        }
        public string GetOccupiedTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Number of people: {numberOfPeople}");

            string foodOrders = this.foodOrders.Count > 0 ? this.foodOrders.Count.ToString() : "None";
            string drinkOrders = this.drinkOrders.Count > 0 ? this.drinkOrders.Count.ToString() : "None";

            result.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.foodOrders)
            {
                result.AppendLine(food.ToString());
            }
            result.AppendLine($"Drink orders: {drinkOrders}");

            foreach (var drink in this.drinkOrders)
            {
                result.AppendLine(drink.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }
        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);

        }
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;

        }
    }
}