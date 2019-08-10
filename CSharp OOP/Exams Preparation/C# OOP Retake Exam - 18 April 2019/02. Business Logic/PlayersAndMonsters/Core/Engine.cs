using System;
using System.Linq.Expressions;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine

    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();
                if (line == "Exit")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];
                string result = String.Empty;
                string cardName;
                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string playerType = tokens[1];
                            string playerUsername = tokens[2];
                            result = this.managerController.AddPlayer(playerType, playerUsername);
                            break;

                        case "AddCard":
                            string cardType = tokens[1];
                            cardName = tokens[2];
                            result = this.managerController.AddCard(cardType, cardName);
                            break;

                        case "AddPlayerCard":
                            string username = tokens[1];
                            cardName = tokens[2];
                            result = this.managerController.AddPlayerCard(username, cardName);
                            break;

                        case "Fight":
                            string attaker = tokens[1];
                            string enemy = tokens[2];
                            result = this.managerController.Fight(attaker, enemy);
                            break;

                        case "Report":
                            result = this.managerController.Report();
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                this.writer.WriteLine(result);
            }
        }
    }
}
