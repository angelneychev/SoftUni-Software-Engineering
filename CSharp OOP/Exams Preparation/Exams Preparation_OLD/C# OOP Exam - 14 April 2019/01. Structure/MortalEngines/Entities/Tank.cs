using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {

        private const double InitialHealthPoints = 100;
        private const double InitialAttackPoints = 40;
        private const double InitialDefensePoints = 30;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - 40,
                defensePoints + 30,
                InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                base.AttackPoints += 40;
                base.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                base.AttackPoints -= 40;
                base.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Defense: ");
            sb.AppendLine(DefenseMode == true ? "ON" : "OFF");
            return sb.ToString().TrimEnd();
        }
    }
}
