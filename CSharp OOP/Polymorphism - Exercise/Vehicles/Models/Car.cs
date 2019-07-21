﻿using System;
namespace Vehicles.Models
{
    public class Car : Vehicles
    {
        private const double AirCondition = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            :base(fuelQuantity,fuelConsumption)
        {
            this.FuelConsumption += AirCondition;
        }
        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
