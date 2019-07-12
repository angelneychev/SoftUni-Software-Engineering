namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Exceptions;
    using System;

    public class Player
    {
        private string name;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }
        
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionsMessages.EmtyNameException);
                }

                this.name = value;
            }
        }

        public double OverallSkill => 
            this.Stat.OveralStat;

        public Stat Stat { get; private set; }

    }
}
