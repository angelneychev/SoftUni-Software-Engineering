using System;
using System.Linq;

namespace MyCoolCarSystem
{
    using MyCoolCarSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using MyCoolCarSystem.Data.Models;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();
            db.Database.Migrate();
            //var customer = db.Customers.FirstOrDefault();
            //customer.Address = new Address
            //{
            //    Text = "Tintiava 15",
            //    Town = "Sofia"
            //};

            //var car = db.Cars.FirstOrDefault();
            //var customer = new Customer
            //{
            //    FistName = "Ivan",
            //    LastName = "Peshov",
            //    Age = 29
            //};

            //customer.Puschases.Add( new CarPurchase
            //{
            //    Car = car,
            //    PurchaseDate = DateTime.Now.AddDays(-10),
            //    Price = car.Price * 0.9m
            //});
            //db.Customers.Add(customer);

            //var insigniaModel = db.Models.FirstOrDefault(m => m.Name == "Insignia");

            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "Black",
            //    Price = 20000,
            //    ProductionDate = DateTime.Now.AddDays(-100),
            //    Vin = "1dsaa3232jjkas"

            //});
            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "White",
            //    Price = 25000,
            //    ProductionDate = DateTime.Now.AddDays(-200),
            //    Vin = "1ds23sdsa2jjkas"

            //});
            //insigniaModel.Cars.Add(new Car
            //{
            //    Color = "Orange",
            //    Price = 18000,
            //    ProductionDate = DateTime.Now.AddDays(-300),
            //    Vin = "1dsa3233234kas"

            //});
            //var opelMake = db.Makes.FirstOrDefault(m => m.Name == "Opel");
            //opelMake.Models.Add(new Model
            //{
            //    Name = "Astra",
            //    Year = 2017,
            //    Modification = "OPC"
            //});
            //opelMake.Models.Add(new Model
            //{
            //    Name = "Insignia",
            //    Year = 2019,
            //    Modification = "2.2 TDI"
            //});

            //db.Makes.Add(new Make
            //{
            //    Name = "Mercedes"
            //});
            //db.Makes.Add(new Make
            //{
            //    Name = "BMW"
            //});
            //db.Makes.Add(new Make
            //{
            //    Name = "Audi"
            //});
            //db.Makes.Add(new Make
            //{
            //    Name = "Opel"
            //});
            //db.Makes.Add(new Make
            //{
            //    Name = "Peugeot"
            //});
            db.SaveChanges();

        }
    }
}
