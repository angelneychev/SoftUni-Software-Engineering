using System.Collections.Generic;
using System.Linq;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Model;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        //HirePilot Command
        //PilotReport Command 
        private readonly List<IPilot> pilots;
        //MachineReport
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(x => x.Name == name))
            {
                //if the pilot with the given name already exists and  you should not create a pilot. 
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                //Add Pilot
                IPilot pilot = new Pilot(name);
                this.pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }
        //ManufactureTank Command
        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x=>x.Name == name && x.GetType().Name == nameof(Tank)))
            {
                //•	"Machine {name} is manufactured already" – if tank with the given name exists and you should not create a tank.
                return string.Format(OutputMessages.MachineExists);
            }
            else
            {
                //•	"Tank {name} manufactured - attack: {attack}; defense: {defense}"
                ITank tank = new Tank(name,attackPoints,defensePoints);
                this.machines.Add(tank);

                return string.Format(OutputMessages.TankManufactured,
                    tank.Name,
                    tank.AttackPoints,
                    tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name && x.GetType().Name == nameof(Fighter)))
            {
                //•	"Machine {name} is manufactured already"
                //– if fighter with the given name exists and you should not create a figher. 
                return string.Format(OutputMessages.MachineExists);
            }
            else
            {
                //•	"Fighter {name} manufactured
                //- attack: {attack}; defense: {defense}; aggressive: ON"

                IFighter fighter = new Fighter(name,attackPoints,defensePoints);
                this.machines.Add(fighter);

                return string.Format(OutputMessages.FighterManufactured,
                    fighter.Name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    fighter.AggressiveMode == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            if (pilot == null)
            {
                //•	"Pilot {pilot name} could not be found"
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);
            if (machine == null)
            {
                //•	"Machine {machine name} could not be found"
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            
            if (machine.Pilot != null)
            {
                //•	"Machine {machine name} is already occupied"
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            //•	"Pilot {pilot name} engaged machine {machine name}"
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attacker = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            IMachine enemy = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (enemy== null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (enemy.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(enemy);

            return string.Format(OutputMessages.AttackSuccessful, 
                enemy.Name, 
                attacker.Name,
                enemy.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(x => x.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(x => x.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter =
                (Fighter) this.machines.FirstOrDefault(x =>
                    x.Name == fighterName && x.GetType().Name == nameof(Fighter));

            if (fighter == null)
            {
                //•	"Machine {name} could not be found" – if fighter with the given name doesn't exist 
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                fighter.ToggleAggressiveMode();
                //•	"Fighter {name} toggled aggressive mode"
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (Tank)this.machines
                .FirstOrDefault(x => x.Name == tankName && x.GetType().Name == nameof(Tank));

            if (tank == null)
            {
                //•	"Machine {name} could not be found" – if tank with the given name doesn't exist 
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                //•	"Tank {name} toggled defense mode"
                tank.ToggleDefenseMode();

                return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
            }
        }
    }
}