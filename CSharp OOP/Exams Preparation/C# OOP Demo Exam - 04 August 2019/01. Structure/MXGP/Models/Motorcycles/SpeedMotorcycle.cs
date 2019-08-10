using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;

        private const double PowerMotorcycleCubicCentimeters = 125;
        private const double PowerMotorcycleMinHP = 50;
        private const double PowerMotorcycleMaxHP = 59;

        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, PowerMotorcycleCubicCentimeters)
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
