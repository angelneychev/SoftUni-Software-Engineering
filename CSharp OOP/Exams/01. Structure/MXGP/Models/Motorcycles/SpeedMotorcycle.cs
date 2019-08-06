using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;
        private const int PowerMotorcycleCubicCentimeters = 450;
        private const int PowerMotorcycleMinHP = 70;
        private const int PowerMotorcycleMaxHP = 100;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)
        {

        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < PowerMotorcycleMinHP || value > PowerMotorcycleMaxHP)
                {
                    //TODO value
                    throw new ArgumentException($"Invalid horse power: {this.horsePower}.");
                }
                this.horsePower = value;
            }
        }
    }
}
