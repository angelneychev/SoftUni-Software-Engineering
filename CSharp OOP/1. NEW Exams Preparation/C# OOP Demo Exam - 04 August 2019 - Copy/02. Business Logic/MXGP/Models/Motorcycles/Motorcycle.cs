﻿using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        //string model, int horsePower, double cubicCentimeters
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; }
        public double CubicCentimeters { get; }
        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
