using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Exceptions;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }

        //•	FoodOrders – collection of foods accessible only by the base class.
        public IReadOnlyCollection<IFood> FoodOrders { get; private set; }
        //•	DrinkOrders – collection of drinks accessible only by the base class. 
        public IReadOnlyCollection<IDrink> DrinkOrders { get; private set; }
        //•	TableNumber – int the table number 
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <=0)
                {
//•	Capacity – int the table capacity (capacity can’t be less than zero. In these cases, throw an ArgumentException with message
//"Capacity has to be greater than 0")
                    throw new ArgumentException(ExceptionMessages.NegativeTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
//•	NumberOfPeople – int the count of people who want a table (number of people cannot be less or equal to 0. In these cases, throw an ArgumentException with message
//"Cannot place zero or less people!")
                if (value <=0)
                {
                    throw  new ArgumentException(ExceptionMessages.NegativeNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        //•	PricePerPerson – decimal the price per person for the table
        public decimal PricePerPerson { get; private set; }
        //•	IsReserved – bool returns true if the table is reserved
        public bool IsReserved { get; private set; }
        //•	Price – calculated property, which calculates the price for all people
        public decimal Price { get; private set; }

        public void Reserve(int numberOfPeople)
        {
            //Reserves the table with the count of people given.

            if (numberOfPeople <=this.Capacity )
            {
                this.IsReserved = true;
                this.numberOfPeople = numberOfPeople;
            }
        }

        public void OrderFood(IFood food)
        {
            //Orders the provided food (think of a way to collect all the food which is ordered).
            this.foodOrders.Add(food);

        }

        public void OrderDrink(IDrink drink)
        {
            //Orders the provided drink (think of a way to collect all the drinks which are ordered).
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            //Returns the bill for all of the ordered drinks and food.
            decimal foodPrice = this.foodOrders.Sum(f => f.Price);
            decimal drinkPrice = this.drinkOrders.Sum(d => d.Price);

            decimal totalSum = foodPrice + drinkPrice + this.Price;

            return totalSum;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            //Return a string with the following format:
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            //If there aren’t any food orders append the following message to the text above:
            if (this.foodOrders.Count == 0)
            {
                //"Food orders: None"
                sb.AppendLine("Food orders: None");
            }
            else
            {
                //"Food orders: {food orders count}"
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                //Finally append each food ToString() method
                foreach (IFood food in this.foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }
            //The same logic you can use for the ordered drinks. If there aren’t any drink orders just append the message:
            if (this.drinkOrders.Count == 0)
            {
                //"Drink orders: None"
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                //"Drink orders: {drink orders count}"
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                //Finally append each drink ToString() method. 
                foreach (IDrink drink in this.drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
