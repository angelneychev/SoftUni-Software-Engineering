﻿using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        //•	Team – TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId

        //•	A Team has one PrimaryKitColor and one SecondaryKitColor
        //•	A Team residents in one Town
        //•	A Player can play for one Team and one Team can have many Players

        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }


        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    }
}
