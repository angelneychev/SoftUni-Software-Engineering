namespace MortalEngines.Entities.Model
{
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        //Has 100 initial health points.
        private const int InitialHealthPoints = 100;
        private const int ActivatedAttackPoints = 40;
        private const int DeactivatedDeffencePoints = 30;

        // DefenseMode – boolo	true by default

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, 
                InitialHealthPoints, 
                attackPoints - ActivatedAttackPoints, 
                defensePoints + DeactivatedDeffencePoints)
        {
            // DefenseMode – boolo	true by default

            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= ActivatedAttackPoints;
                this.DefensePoints += DeactivatedDeffencePoints;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += ActivatedAttackPoints;
                this.DefensePoints -= DeactivatedDeffencePoints;
            }
        }

        public override string ToString()
        {
            // " *Defense: {ON/OFF}"

            StringBuilder sb = new StringBuilder();
          
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
