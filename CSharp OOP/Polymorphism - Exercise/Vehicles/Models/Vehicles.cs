namespace Vehicles.Models
{
    using System;
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicles(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set => this.fuelConsumption = value;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set => this.fuelQuantity = value;
        }
        public string Driver(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";

        }
        public abstract void Refuel(double fuel);
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
