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

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (pilot == null)
                {
                    throw new NullReferenceException("Machine name cannot be null or empty.");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public IList<string> Targets { get; private set; }


        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double diff = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.DefensePoints - diff <= 0)
            {
                this.HealthPoints = 0;
            }
            else
            {
                this.HealthPoints -= diff;
            }
            this.Targets.Add(target.Name);
        }

        public virtual string ToString()
        {
            StringBuilder sb = new StringBuilder();



            //Returns a string with information about each machine. The returned string must be in the following format:
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");
            if (Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
