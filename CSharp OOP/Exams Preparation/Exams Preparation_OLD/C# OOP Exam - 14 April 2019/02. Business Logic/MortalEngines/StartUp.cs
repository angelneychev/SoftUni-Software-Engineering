using System;
using System.Linq;
using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            var manager = new MachinesManager();
            while (true)
            {
                var commands = Console.ReadLine().Split(' ').ToArray();
                string mainCommand = commands[0];
                if (mainCommand == "Quit")
                {
                    break;
                }
                try
                {
                    switch (mainCommand)
                    {
                        case "HirePilot":
                            string name = commands[1];
                            Console.WriteLine(manager.HirePilot(name));
                            break;
                        case "PilotReport":
                            manager.PilotReport(commands[1]);
                            break;
                        case "ManufactureTank":
                            Console.WriteLine(manager.ManufactureTank(commands[1], double.Parse(commands[2]), double.Parse(commands[3])));
                            break;
                        case "ManufactureFighter":
                            Console.WriteLine(manager.ManufactureFighter(commands[1], double.Parse(commands[2]), double.Parse(commands[3])));
                            break;
                        case "MachineReport":
                            Console.WriteLine(manager.MachineReport(commands[1]));
                            break;
                        case "AggressiveMode":
                            Console.WriteLine(manager.ToggleFighterAggressiveMode(commands[1]));
                            break;
                        case "DefenseMode":
                            Console.WriteLine(manager.ToggleTankDefenseMode(commands[1]));
                            break;
                        case "Engage":
                            Console.WriteLine(manager.EngageMachine(commands[1], commands[2]));
                            break;
                        case "Attack":
                            Console.WriteLine(manager.AttackMachines(commands[1], commands[2]));
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}