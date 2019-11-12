using System.Collections.Generic;
using System.Linq;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots = new List<IPilot>();
        private List<IMachine> machines = new List<IMachine>();


        public string HirePilot(string name)
        {

            if (!pilots.Any(x=>x.Name == name))
            {
                IPilot pilot = new Pilot(name);
                pilots.Add(pilot);
                return $"Pilot {name} hired";
            }
            else
            {
                return $"Pilot {name} is hired already";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            throw new System.NotImplementedException();
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            throw new System.NotImplementedException();
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string PilotReport(string pilotReporting)
        {
            throw new System.NotImplementedException();
        }

        public string MachineReport(string machineName)
        {
            throw new System.NotImplementedException();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            throw new System.NotImplementedException();
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            throw new System.NotImplementedException();
        }
    }
}