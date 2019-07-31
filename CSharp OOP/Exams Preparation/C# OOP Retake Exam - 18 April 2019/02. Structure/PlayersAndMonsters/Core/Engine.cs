using System;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly ManagerController controller;

        public Engine()
        {
            this.controller = new ManagerController();
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
                        case "AddPlayer":
                            Console.WriteLine(this.controller.AddPlayer(commandItems[1], commandItems[2]));
                            break;

                        case "AddCard":
                            Console.WriteLine(this.controller.AddCard(commandItems[1], commandItems[2]));
                            break;

                        case "AddPlayerCard":
                            Console.WriteLine(this.controller.AddPlayerCard(commandItems[1], commandItems[2]));
                            break;

                        case "Fight":
                            Console.WriteLine(this.controller.Fight(commandItems[1], commandItems[2]));
                            break;

                        case "Report":
                            Console.WriteLine(this.controller.Report());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(this.controller.Report());
        }
    }
}
