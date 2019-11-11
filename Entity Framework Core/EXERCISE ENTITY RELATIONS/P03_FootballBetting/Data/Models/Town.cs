﻿using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        //•	Town – TownId, Name, CountryId
        //•	A Town can host several Teams
        //•	A Town can be placed in one Country and a Country can have many Towns

        public int TownId { get; set; }

        public string Name { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new  HashSet<Team>();
    }
}
