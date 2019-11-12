using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(
                name, 
                attackPoints + 50,
                defensePoints - 25,
                InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                this.AggressiveMode = false;
                base.AttackPoints -= 50;
                base.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                base.AttackPoints += 50;
                base.DefensePoints -= 25;
            }
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Aggressive: ");
            sb.AppendLine(AggressiveMode == true ? "ON" : "OFF");
            return sb.ToString().TrimEnd();
        }
    }
}
