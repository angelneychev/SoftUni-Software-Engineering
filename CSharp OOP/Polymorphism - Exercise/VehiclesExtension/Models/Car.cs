namespace VehiclesExtension.Models
{
    public class Car : Vehicles
    {
        private const double AirCondition = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondition;
        }
    }
}
