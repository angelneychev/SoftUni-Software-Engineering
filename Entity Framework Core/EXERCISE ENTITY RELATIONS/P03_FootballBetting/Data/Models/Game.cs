﻿namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    public class Game
    {
        //•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)

        //•	A Game has one HomeTeam and one AwayTeam and a Team can have many HomeGames and many AwayGames
        ////•	One Player can play in many Games and in each Game, many Players take part (both collections must be named PlayerStatistics)
        //•	Many Bets can be placed on one Game, but a Bet can be only on one Game
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        public int Result { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}
