namespace MortalEngines.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;

    public class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        //A base machine should take the following values upon initialization:
        //string name, double attackPoints, double defensePoints, double healthPoints
        protected BaseMachine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullMachineName);

                }
                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get => this.pilot;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.NullPilot);

                }
            }
        }
        public double HealthPoints { get; set; }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            // If the target is null throw NullReferenceException with message "Target cannot be null".
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullTarget);
            }

            //The machine attacks the target and decreases the target's health by the difference between the attacker's attack points and target's defense points.

            double differencePoints = Math.Abs(this.AttackPoints - target.DefensePoints);

            double currentPoints = this.HealthPoints - differencePoints;

            if (currentPoints < 0)
            {
                //If the health of the target become less than zero, set it to zero.
                this.HealthPoints = 0;
            }
            else
            {
                this.HealthPoints -= differencePoints;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            //Returns a string with information about each machine. The returned string must be in the following format:
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
