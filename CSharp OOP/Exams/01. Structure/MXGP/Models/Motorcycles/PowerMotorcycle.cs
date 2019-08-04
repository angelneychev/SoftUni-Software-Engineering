using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int PowerHorseCubicCentimeters = 450;
        private const int PowerHorseMinHP = 70;
        private const int PowerHorseMaxHP = 100;



        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) 
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

        //•	HorsePower – int
        //    o   Every type of motorcycle has different range of valid horsepower.If the horsepower is not in the valid range, throw an ArgumentException with message "Invalid horse power: {horsepower}."
    }
}
