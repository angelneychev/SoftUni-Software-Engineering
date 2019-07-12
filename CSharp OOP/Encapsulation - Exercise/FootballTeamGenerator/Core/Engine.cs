namespace FootballTeamGenerator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FootballTeamGenerator.Models;
    using System.ComponentModel.DataAnnotations;
    using FootballTeamGenerator.Exceptions;

    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {

                    string[] tokens = command
                        .Split(";")
                        .ToArray();
                    string cmdType = tokens[0];
                    string teamName = tokens[1];

                    if (cmdType =="Team")
                    {
                        AddTeam(teamName);
                    }
                    else if(cmdType == "Add")
                    {
                        AddPlayerToATeam(teamName, tokens);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayerFromATeam(teamName, tokens);
                    }
                    else if (cmdType == "Rating")
                    {
                        RatingTeam(teamName);
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }
        }

        private void RatingTeam(string teamName)
        {
            ValidateTeamName(teamName);
            Team team = this.teams
                .First(x => x.Name == teamName);
            Console.WriteLine(team.ToString());
        }

        private void RemovePlayerFromATeam(string teamName, string[] tokens)
        {
            ValidateTeamName(teamName);
            string playerName = tokens[2];

            Team team = this.teams
                .First(x => x.Name == teamName);
            team.RemovePlayer(playerName);
        }

        private void AddPlayerToATeam(string teamName, string[] tokens)
        {
            ValidateTeamName(teamName);

            string playerName = tokens[2];
            Stat stat = CreateStat(tokens);

            Player player = new Player(playerName, stat);
            Team team = this.teams
                .FirstOrDefault(x => x.Name == teamName);

            team.AddPlayer(player);
        }

        private void AddTeam(string teamName)
        {
            Team team = new Team(teamName);
            this.teams.Add(team);
        }

        private static Stat CreateStat(string[] tokens)
        {
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
            return stat;
        }

        private void ValidateTeamName(string name)
        {
            Team team = this.teams
                .FirstOrDefault(x => x.Name == name);
            if (team == null)
            {
                throw new ArgumentException(string.Format(ExceptionsMessages.MissingTeamException, name));
            }
        }


    }
}
