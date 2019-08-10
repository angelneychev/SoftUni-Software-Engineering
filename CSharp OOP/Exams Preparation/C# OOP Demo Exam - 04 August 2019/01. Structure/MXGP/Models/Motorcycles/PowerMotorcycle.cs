using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        private const double PowerMotorcycleCubicCentimeters = 450;
        private const double PowerMotorcycleMinHP = 70;
        private const double PowerMotorcycleMaxHP = 100;

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
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
