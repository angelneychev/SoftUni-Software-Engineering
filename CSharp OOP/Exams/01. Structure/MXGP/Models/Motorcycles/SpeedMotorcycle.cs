using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int PowerHorseCubicCentimeters = 125;
        private const int PowerHorseMinHP = 50;
        private const int PowerHorseMaxHP = 69;



        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, PowerHorseCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < PowerHorseMinHP || value > PowerHorseMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
