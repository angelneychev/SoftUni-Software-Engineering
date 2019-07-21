using System;
using System.Linq;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
{
    public class Engine
    {
        public void Run()
        {
            //Car
            string[] carInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();
            double carQuantity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            var car = new Car(carQuantity, carConsumption, carCapacity);

            //Truck
            string[] truckInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();
            double truckQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            var truck = new Truck(truckQuantity, truckConsumption, truckCapacity);

            //Bus
            string[] busInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();
            double busQuantity = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            var bus = new Bus(busQuantity, busConsumption, busCapacity);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string command = tokens[0];
                    string type = tokens[1];

                    if (command == "Drive")
                    {
                        double distance = double.Parse(tokens[2]);
                        if (type == "Car")
                        {
                            Console.WriteLine(car.Driver(distance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Driver(distance));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(bus.Driver(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double fuel = double.Parse(tokens[2]);
                        if (type == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(tokens[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
