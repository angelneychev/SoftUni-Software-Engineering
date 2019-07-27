using System;

namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IMachinesManager manager;

        public Engine()
        {
            this.manager = new MachinesManager();
        }
        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "Quit")
            {
                string[] tokens = inputLine.Split();
                string result = string.Empty;
                string command = tokens[0];
                try
                {
                    //•	HirePilot {name}
                    if (command == "HirePilot")
                    {
                        result += this.manager.HirePilot(tokens[1]);
                    }
                    //•	PilotReport { name}
                    else if (command == "PilotReport")
                    {
                        result += this.manager.PilotReport(tokens[1]);
                    }
                    //•	ManufactureTank { name}
                    else if (command == "ManufactureTank")
                    {
                        //{ attack}
                        //{ defense}
                        result += this.manager.ManufactureTank(tokens[1],
                            double.Parse(tokens[2]),
                            double.Parse(tokens[3]));
                    }
                    //•	ManufactureFighter { name}
                    else if (command == "ManufactureFighter")
                    {
                        //{ attack}
                        //{ defense}
                        result += this.manager.ManufactureFighter(tokens[1],
                            double.Parse(tokens[2]),
                            double.Parse(tokens[3]));
                    }
                    //•	MachineReport { name}
                    else if (command == "MachineReport")
                    {
                        result += this.manager.MachineReport(tokens[1]);
                    }
                    //•	AggressiveMode { name}
                    else if (command == "AggressiveMode")
                    {
                        result += this.manager.ToggleFighterAggressiveMode(tokens[1]);
                    }
                    //•	DefenseMode { name}
                    else if (command == "DefenseMode")
                    {
                        result += this.manager.ToggleTankDefenseMode(tokens[1]);
                    }
                    //•	Engage { pilot name}
                    else if (command == "Engage")
                    {
                        //{ machine name}
                        result += this.manager.EngageMachine(tokens[1], tokens[2]);
                    }
                    //•	Attack { attacking machine name}
                    else if (command == "Attack")
                    {
                        //{ defending machine name}
                        result += this.manager.AttackMachines(tokens[1], tokens[2]);
                    }

                }
                catch (Exception ex)
                {
                    //•	 "Error:" plus the message of the exception
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine(result);
                inputLine = Console.ReadLine();
            }
        }
    }
}
