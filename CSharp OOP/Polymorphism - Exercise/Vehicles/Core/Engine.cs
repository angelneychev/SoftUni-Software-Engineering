using System.Linq;
using Vehicles.Models;
using System;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();
            double carQuantity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);

            Car car = new Car(carQuantity, carConsumption);

            string[] truckInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();
            double truckQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);

            Truck truck = new Truck(truckQuantity, truckConsumption);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ")
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
                }
                else if(command == "Refuel")
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
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}