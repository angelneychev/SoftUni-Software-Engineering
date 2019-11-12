
using System;
using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] commandItems = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (commandItems[0])
                    {
                        case "CreateRider":
                            Console.WriteLine(this.championshipController.CreateRider(commandItems[1]));
                            break;

                        case "CreateMotorcycle":
                            Console.WriteLine(this.championshipController.CreateMotorcycle(
                                commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3])));
                            break;

                        case "CreateRace":
                            Console.WriteLine(this.championshipController.CreateRace(
                                commandItems[1],
                                int.Parse(commandItems[2])));
                            break;

                        case "AddRiderToRace":
                            Console.WriteLine(this.championshipController.AddRiderToRace(commandItems[1], commandItems[2]));
                            break;

                        case "AddMotorcycleToRider":
                            Console.WriteLine(this.championshipController.AddMotorcycleToRider(
                                commandItems[1],
                                commandItems[2]));
                            break;
                       default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(this.championshipController.GetType());
        }
    }
}
