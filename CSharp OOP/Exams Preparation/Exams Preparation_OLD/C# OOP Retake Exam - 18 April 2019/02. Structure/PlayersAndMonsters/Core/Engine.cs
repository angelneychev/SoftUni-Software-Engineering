using System;
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
                string line = Console.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                string[] tokens = line.Split();

                string command = tokens[0];
                string result = String.Empty;
                string cardName= String.Empty;
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
                        //AddPlayerCard handyUser33 Cyber
                        string username = tokens[1];
                        cardName = tokens[2];
                        result = this.managerController.AddPlayerCard(username, cardName);
                        break;
                    case "Fight":
                        break;
                    case "Report":
                        break;
                }
                this.writer.WriteLine(result);
            }
        }
    }
}
