using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }
        public int Count => this.gladiators.Count;

        //•	Method Add(Gladiator gladiator) – adds an gladiator to the arena.
        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }
        //•	Method Remove(string name) – removes an gladiator by given name.
        public void Remove(string name)
        {
            Gladiator gladiatorName = this.gladiators.FirstOrDefault(x => x.Name == name);
            this.gladiators.Remove(gladiatorName);

        }
        //•	Method GetGladitorWithHighestStatPower() – returns the Gladiator which has the highest stat.
        public Gladiator GetGladitorWithHighestStatPower()
        {
            int highestStatPower = this.gladiators.Max(x => x.GetStatPower());
            return this.gladiators.FirstOrDefault(x => x.GetStatPower() == highestStatPower);
        }
        //•	Method GetGladitorWithHighestWeaponPower() – returns the Gladiator which poses the weapon with the highest power.
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int highestWeaponPower = this.gladiators.Max(x => x.GetWeaponPower());
            return this.gladiators.FirstOrDefault(x => x.GetWeaponPower() == highestWeaponPower);
        }
        //•	Method GetGladitorWithHighestTotalPower() – returns the Gladiator which has the highest total power.
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int highestTotalPower = this.gladiators.Max(x => x.GetTotalPower());
            return this.gladiators.FirstOrDefault(x => x.GetTotalPower() == highestTotalPower);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.gladiators.Count} gladiators are participating.";
        }
    }
}
