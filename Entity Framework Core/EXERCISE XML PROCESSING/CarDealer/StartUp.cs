using CarDealer.Dtos.Export;

namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Models;
    using System.IO;
    using System.Xml.Serialization;
    using Dtos.Import;
    using Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();

            });

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                // var xmlPath = File.ReadAllText(@"Datasets/parts.xml");
                //var xmlPath = File.ReadAllText(@"./../../../Datasets/sales.xml");

                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }

        }
        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";

        }
        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));
            var partsDto = ((ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();
            
            var parts = Mapper.Map<Part[]>(partsDto);
            
            context.Parts.AddRange(parts);

            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            var carsDto = (ImportCarDto[]) xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };
                var parts = carDto
                    .Parts
                    .Where(pc=> context.Parts.Any(p=>p.Id == pc.Id))
                    .Select(p => p.Id)
                    .Distinct();
                foreach (var part in parts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}"; ;
        }
        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));


            var customerDto = ((ImportCustomerDto[]) xmlSerializer.Deserialize(new StringReader(inputXml)));

            var customers = Mapper.Map<Customer[]>(customerDto);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.Find(saleDto.CarId) != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";


        }
        //Query 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportLocalCarsWithDistanceDto>()
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportLocalCarsWithDistanceDto[]),
                    new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportLocalCarsBmwDto>()
                .ToArray();
            var xmlSerializer =
                new XmlSerializer(typeof(ExportLocalCarsBmwDto[]),
                    new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportLocalSuppliersDto>()
                .ToArray();
          
            var xmlSerializer = 
                new XmlSerializer(typeof(ExportLocalSuppliersDto[]), 
                    new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 17. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportLocalCarDto>()
                .ToArray();

            foreach (var car in cars)
            {
                car.Parts = car.Parts
                    .OrderByDescending(p => p.Price)
                    .ToArray();
            }
                
            var xmlSerializer =
                new XmlSerializer(typeof(ExportLocalCarDto[]),
                    new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 18. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customer = context
                .Customers
                .Where(c => c.Sales.Any())
                .ProjectTo<ExportLocalCustomerDto>()
                .OrderByDescending(cs=>cs.CarSaleSum)
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportLocalCustomerDto[]),
                    new XmlRootAttribute("customers"));
            
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customer, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 19. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesCar = context
                .Sales
                .ProjectTo<ExportLocalSalesDiscountDto>()
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportLocalSalesDiscountDto[]),
                    new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), salesCar, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}