﻿using System;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Riders
{
    public abstract class Rider : IRider
    {
        private string name;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {this.name} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate => this.Motorcycle != null;
        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle),"motorcycle is not null");
            }

            this.Motorcycle = motorcycle;
        }
    }
}