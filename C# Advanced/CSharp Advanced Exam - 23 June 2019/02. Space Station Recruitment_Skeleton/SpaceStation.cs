using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count() < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string astronautName)
        {
            if (this.data.FirstOrDefault(x=>x.Name == astronautName) !=null)
            {
                this.data.Remove(this.data.FirstOrDefault(x => x.Name == astronautName));
                return true;
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            int max = this.data.Max(x => x.Age);
            return this.data.FirstOrDefault(x => x.Age == max);
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();


            //Astronauts working at Space Station Apolo:
            //Astronaut: Stephen, 40 (Bulgaria)
            //Astronaut: Mark, 34 (UK)
            //o	"Astronauts working at Space Station {spaceStationName}:
            //{ Astronaut1}
            //{ Astronaut2}
            //(…)"
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
