using System;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        private const int PowerMotorcycleCubicCentimeters= 125;
        private const int PowerMotorcycleMinHP = 50;
        private const int PowerMotorcycleMaxHP = 69;

        public PowerMotorcycle(string model, int horsePower) 
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
