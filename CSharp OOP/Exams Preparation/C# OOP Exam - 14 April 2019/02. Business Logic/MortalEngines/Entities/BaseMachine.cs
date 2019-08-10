using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
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
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set => this.healthPoints = value;
        }
        public double AttackPoints
        {
            get => this.attackPoints;
            protected set => this.attackPoints = value;
        }
        public double DefensePoints
        {
            get => this.defensePoints;
            protected set => this.defensePoints = value;
        }
        public IList<string> Targets => this.targets;
        public void Attack(IMachine target)
        {
            if (targets == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double hpDecreasment = this.AttackPoints - target.DefensePoints;

            target.HealthPoints -= hpDecreasment;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");
            if (Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
            // string targetsOutpu = this.targets.Count > 0 ? string.Join(",", this.targets) : "None";

            //sb.AppendLine($"- {this.Name}")
            //.AppendLine($" *Type: {this.GetType().Name}")
            //.AppendLine($" *Health: {this.HealthPoints}")
            //.AppendLine($" *Attack: {this.AttackPoints}")
            //.AppendLine($" *Defense: {this.DefensePoints}")
            //.AppendLine($" *Targets: {targetsOutpu}");

            // return sb.ToString().TrimEnd();
        }
    }
}
