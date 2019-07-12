namespace FootballTeamGenerator.Models
{
    using  System;
    using System.Collections.Generic;
    using System.Linq;
    using FootballTeamGenerator.Exceptions;

    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name

        {
            get { return this.name;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new  ArgumentException(ExceptionsMessages.EmtyNameException);
                }
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                else
                {
                   return (int)(Math.Round(this.players.Average(x => x.OverallSkill), 0));
                }
            }
        }

        //Добавяме играчи
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players
                .FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionsMessages.MissingPlayerException,name,this.Name));
            }

            this.players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
