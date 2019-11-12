using System;
using System.Collections;
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
        //FoodOrders – collection of foods accessible only by the base class.
        private IList<IFood> foodOrders;
        //DrinkOrders – collection of drinks accessible only by the base class. 
        private IList<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        //IsReserved – bool returns true if the table is reserved
        //Capacity – int the table capacity(capacity can’t be less than zero.In these cases, throw an ArgumentException with message "Capacity has to be greater than 0")
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        //NumberOfPeople – int the count of people who want a table(number of people cannot be less or equal to 0. In these cases, throw an ArgumentException with message "Cannot place zero or less people!")
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }
        //TableNumber – int the table number
        public int TableNumber { get; }
        public bool IsReserved { get; private set; }
        //Price – calculated property, which calculates the price for all people
        public decimal Price => this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price) +
                                this.pricePerPerson * this.numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.pricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Price per Person: {pricePerPerson:F2}");

            return sb.ToString().TrimEnd();

        }
        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {numberOfPeople}");

            string foodOrders = this.foodOrders.Count > 0 ? this.foodOrders.Count.ToString() : "None";

            string drinkOrders = this.drinkOrders.Count > 0 ? this.drinkOrders.Count.ToString() : "None";

            sb.AppendLine($"Food orders: {foodOrders}");
            foreach (var food in this.foodOrders)
            {
                sb.AppendLine(food.ToString());
            }

            sb.AppendLine($"Drink orders: {drinkOrders}");
            foreach (var drink in this.drinkOrders)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
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
            this.numberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
