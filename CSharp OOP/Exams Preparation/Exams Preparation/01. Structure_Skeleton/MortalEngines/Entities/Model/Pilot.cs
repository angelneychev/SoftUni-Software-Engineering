namespace MortalEngines.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;

    public class Pilot : IPilot
    {
        //•	Machines – collection of machines
        private readonly List<IMachine> machines;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines= new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                //•	Name – string (If the pilot name is null or whitespace throw ArgumentNullException with message "Pilot name cannot be null or empty string.") 
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullPilotName);

                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            //Adds the provided machine to the pilot’s machines. If the provided machine is null throw NullReferenceException with message "Null machine cannot be added to the pilot."
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullMachine);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            //Returns the message in format:
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            //And for each machine:
            foreach (IMachine machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
