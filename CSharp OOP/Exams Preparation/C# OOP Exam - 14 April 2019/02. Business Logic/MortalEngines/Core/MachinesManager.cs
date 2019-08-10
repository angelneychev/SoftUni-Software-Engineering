using System;
using System.Collections.Generic;
using System.Linq;
using MortalEngines.Common;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots = new List<IPilot>();
        private readonly List<IMachine> machines = new List<IMachine>();
        public string HirePilot(string name)
        {
            if (!pilots.Any(x => x.Name == name))
            {
                Pilot pilot = new Pilot(name);
                pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Tank tank = new Tank(name, attackPoints, defensePoints);
                machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Fighter fighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(fighter);
                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (pilots.All(x => x.Name != selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machines.All(x => x.Name != selectedMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            var machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (machine.Pilot == null)
            {
                var pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);

                machine.Pilot = pilot;

                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
            else
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }


        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!machines.Any(x => x.Name == attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            if (!machines.Any(x => x.Name == defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = (IMachine)this.machines.FirstOrDefault(x => x.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!machines.Any(x => x.Name == fighterName))
            {
                return String.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                var machine = (Fighter)machines.FirstOrDefault(x => x.Name == fighterName);
                machine.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!machines.Any(x => x.Name == tankName))
            {
                return String.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                var machine = (Tank)machines.FirstOrDefault(x => x.Name == tankName);
                machine.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}
//using System.Collections.Generic;
//using System.Linq;
//using MortalEngines.Entities;
//using MortalEngines.Entities.Contracts;

//namespace MortalEngines.Core
//{
//    using Contracts;

//    public class MachinesManager : IMachinesManager
//    {
//        private IList<IPilot> pilots;
//        private IList<IMachine> machines;

//        public MachinesManager()
//        {
//            this.pilots = new List<IPilot>();
//            this.machines = new List<IMachine>();
//        }
//        public string HirePilot(string name) // Назначаваме пилот
//        {
//            if (this.pilots.Any(x => x.Name == name)) // проверява дали съществува
//            {
//                return $"Pilot {name} is hired already";
//            }
//            IPilot pilot = new Pilot(name); // създаваме пилота

//            this.pilots.Add(pilot);

//            return $"Pilot {name} hired";
//        }

//        public string ManufactureTank(string name, double attackPoints, double defensePoints) // Създаваме танкове
//        {
//            if (this.machines.Any(x=>x.Name == name))
//            {
//                return $"Machine {name} is manufactured already";
//            }

//            IMachine tank = new Tank(name,attackPoints,defensePoints);

//            this.machines.Add(tank);

//            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
//        }

//        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
//        {

//            if (this.machines.Any(x=>x.Name == name))
//            {
//                return $"Machine {name} is manufactured already";
//            }
//            IMachine fighter = new Fighter(name,attackPoints,defensePoints);

//            this.machines.Add(fighter);

//            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
//        }

//        public string EngageMachine(string selectedPilotName, string selectedMachineName)
//        {
//            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);

//            if (pilot == null)
//            {
//                return $"Pilot {selectedPilotName} could not be found";
//            }
//            IMachine machine = this.machines.FirstOrDefault(x=>x.Name == selectedMachineName);

//            if (machine == null)
//            {
//                return $"Machine {selectedMachineName} could not be found";
//            }

//            if (machine.Pilot != null)
//            {
//                return $"Machine {selectedMachineName} is already occupied";
//            }

//            pilot.AddMachine(machine);
//            machine.Pilot = pilot;

//            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";

//        }

//        public string AttackMachines(string attackingMachineName, string defendingMachineName)
//        {
//            IMachine attackMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
//            if (attackMachine == null)
//            {
//                return $"Machine {attackMachine} could not be found";
//            }

//            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);
//            if (defendingMachine == null)
//            {
//                return $"Machine {defendingMachine} could not be found";
//            }

//            if (attackMachine.HealthPoints <= 0)
//            {
//                return $"Dead machine {attackMachine} cannot attack or be attacked";
//            }
//            if (defendingMachine.HealthPoints <= 0)
//            {
//                return $"Dead machine {defendingMachine} cannot attack or be attacked";
//            }

//            attackMachine.Attack(defendingMachine);

//            return
//                $"Machine {defendingMachine} was attacked by machine {attackMachine} - current health: {defendingMachine.HealthPoints:f2}";

//        }
//        public string PilotReport(string pilotReporting)
//        {

//            IPilot pilotToReport = this.pilots.FirstOrDefault(x => x.Name == pilotReporting); // Намираме пилота

//            //TODO това написа Фродо, но няма смисъл от него.
//            if (pilotToReport == null)
//            {
//                return $"Pilot{pilotToReport} could not be found";
//            }

//            return pilotToReport.Report();
//        }

//        public string MachineReport(string machineName)
//        {
//            IMachine machine = this.machines.FirstOrDefault(x => x.Name == machineName);

//            if (machine == null)
//            {
//                return $"Machine {machine} could not be found";
//            }

//            return machine.ToString();
//        }

//        public string ToggleFighterAggressiveMode(string fighterName)
//        {
//            IMachine machine = this.machines.FirstOrDefault(x => x.Name == fighterName);

//            if (machine == null)
//            {
//                return $"Machine {fighterName} could not be found";
//            }

//            IFighter fighter = (IFighter) machine;

//            fighter.ToggleAggressiveMode();


//            return $"Fighter {fighterName} toggled aggressive mode";

//        }

//        public string ToggleTankDefenseMode(string tankName)
//        {
//            IMachine machine = this.machines.FirstOrDefault(x => x.Name == tankName);

//            if (machine == null)
//            {
//                return $"Machine {tankName} could not be found";
//            }

//            ITank tank = (ITank) machine;

//            tank.ToggleDefenseMode();

//            return $"Tank {tankName} toggled defense mode";
//        }
//    }
//}