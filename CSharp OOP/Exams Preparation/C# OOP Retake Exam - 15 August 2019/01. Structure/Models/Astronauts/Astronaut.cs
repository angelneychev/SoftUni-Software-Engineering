using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut :IAstronaut
    {
        private string name;

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public double Oxygen { get; set; }
        public bool CanBreath { get; set; }
        public IBag Bag { get; set; }
        public void Breath()
        {
            throw new NotImplementedException();
        }
    }
}
