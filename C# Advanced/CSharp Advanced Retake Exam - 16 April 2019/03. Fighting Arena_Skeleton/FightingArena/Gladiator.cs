using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public int GetTotalPower()
        {
            //GetTotalPower(): int – return the sum of the stat properties plus the sum of the weapon properties.
            return GetWeaponPower() + GetStatPower();
        }
        public int GetWeaponPower()
        {
            //GetWeaponPower(): int - return the sum of the weapon properties.
            return this.Weapon.Sharpness
                   + this.Weapon.Size
                   + this.Weapon.Solidity;
        }
        public int GetStatPower()
        {
            //GetStatPower(): int - return the sum of the stat properties.
            return this.Stat.Agility
                   + this.Stat.Flexibility
                   + this.Stat.Intelligence
                   + this.Stat.Skills
                   + this.Stat.Strength;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            //"[Gladiator name] - [Gladiator total power]"
            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            // "  Weapon Power: [Gladiator weapon power]"
            sb.AppendLine($"Weapon Power: {this.GetWeaponPower()}");
            // "  Stat Power: [Gladiator stat power]"
            sb.AppendLine($"Stat Power: {this.GetStatPower()}");

            return sb.ToString().TrimEnd();
        }
    }
}
