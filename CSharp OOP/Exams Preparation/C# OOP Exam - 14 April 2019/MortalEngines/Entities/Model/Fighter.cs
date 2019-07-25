namespace MortalEngines.Entities.Model
{
    using System.Text;
    using MortalEngines.Entities.Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        //Has 200 initial health points.
        private const int InitialHealthPoints = 200;
        private const int ActivatedAttackPoints = 50;
        private const int DeactivatedDeffencePoints = 25;

        // AggressiveMode – boolo	true by default
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name,
                InitialHealthPoints,
                attackPoints + ActivatedAttackPoints,
                defensePoints - DeactivatedDeffencePoints)
        {
            // AggressiveMode – boolo	true by default
            this.AggressiveMode = true;
        }
        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += ActivatedAttackPoints;
                this.DefensePoints -= DeactivatedDeffencePoints;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= ActivatedAttackPoints;
                this.DefensePoints += DeactivatedDeffencePoints;
            }
        }

        public override string ToString()
        {
            //" *Aggressive: {ON/OFF}"

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
