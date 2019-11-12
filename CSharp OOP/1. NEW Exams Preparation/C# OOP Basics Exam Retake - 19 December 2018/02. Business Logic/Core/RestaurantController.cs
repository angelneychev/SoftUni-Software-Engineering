
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.Factories;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.Factories;
using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.Factories;

namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController
    {
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactroy tableFactroy;
        private decimal income;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactroy = new TableFactroy();
            this.income = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            //fix if foog is null
            IFood food = this.foodFactory.CreateFood(type, name, price);
            menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);

            this.drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactroy.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            //TODO
            int tableNumber = table.TableNumber;
            //TODO
            this.tables.First(x => x.TableNumber == tableNumber);
            //TODO
            table.Reserve(numberOfPeople);

            return $"Table {tableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood food = this.menu.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);


            decimal bill = table.GetBill();

            table.Clear();

            this.income += bill;

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";

        }

        public string GetFreeTablesInfo()
        {
           StringBuilder result = new StringBuilder();

           foreach (var table in tables.Where(x=>!x.IsReserved))
           {
               result.AppendLine(table.GetFreeTableInfo());
           }

           return result.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder result = new StringBuilder();

            foreach (var table in tables.Where(x => x.IsReserved))
            {
                result.AppendLine(table.GetOccupiedTableInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
