using System;
using System.Collections.Generic;
using System.Linq;
//Objects and Classes - Lab
namespace _08._Vehicle_Catalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            List<Truck> Trusk = new List<Truck>();
            List<Car> Car = new List<Car>();
        }
        public List<Truck> Truck { get; set; }
        public List<Car> Car { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalogueVehicle = new Catalog()
            {
                Truck = new List<Truck>(),
                Car = new List<Car>()
            };

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split("/");

                string type = tokens[0];
                string brands = tokens[1];
                string models = tokens[2];
                int weights = int.Parse(tokens[3]);
                int horsePowers = int.Parse(tokens[3]);

                switch (type)
                {
                    case "Truck":
                        Truck newTruck = new Truck()
                        {
                            Brand = brands,
                            Model = models,
                            Weight = weights
                        };
                        catalogueVehicle.Truck.Add(newTruck);
                        break;
                    case "Car":
                        Car newCar = new Car()
                        {
                            Brand = brands,
                            Model = models,
                            HorsePower = horsePowers
                        };
                        catalogueVehicle.Car.Add(newCar);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Cars: ");

            foreach (var car in catalogueVehicle.Car.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks: ");
            foreach (var truck in catalogueVehicle.Truck.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
