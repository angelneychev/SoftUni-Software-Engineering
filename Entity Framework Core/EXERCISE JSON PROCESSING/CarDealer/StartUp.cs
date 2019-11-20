using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //  var context = new CarDealerContext();
            //  //context.Database.EnsureDeleted();
            //  //context.Database.EnsureCreated();

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

               // string json = File.ReadAllText("./../../../Datasets/sales.json");

                string result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }
        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            foreach (var carDto in cars)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";

        }
        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        //3. Query and Export Data
        //Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customerList = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customerList, Formatting.Indented);
            return json;
        }
        //Query 15. Export Cars from make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsToyotaList = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();
            var json = JsonConvert.SerializeObject(carsToyotaList, Formatting.Indented);
            return json;
        }
        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliersList = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();
            var json = JsonConvert.SerializeObject(suppliersList, Formatting.Indented);
            return json;
        }
        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsPartsList = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = $"{pc.Part.Price:f2}"
                        })
                       .ToList()
                })
                .ToList();
            var json = JsonConvert.SerializeObject(carsPartsList, Formatting.Indented);
            return json;
        }
        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomer = context
                .Customers
                .Where(c=>c.Sales.Count() >= 1)
                .Select(x=> new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales
                        .Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(m => m.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();
            var json = JsonConvert.SerializeObject(salesByCustomer, Formatting.Indented);
            return json;
        }
        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesDiscount = context.Sales
                .Select(s => new
                {
                    car = new 
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                                             s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();
            var json = JsonConvert.SerializeObject(salesDiscount, Formatting.Indented);
            return json;
        }
    }
}
