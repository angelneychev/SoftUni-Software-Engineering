using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        //•	Color – ColorId, Name

        //•	A Color has many PrimaryKitTeams and many SecondaryKitTeams

        public int ColorId { get; set; }
        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

        public ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
    }
}
