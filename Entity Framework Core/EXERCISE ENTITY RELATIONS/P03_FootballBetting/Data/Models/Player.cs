namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        //•	Player – PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured

        //•	A Player can play for one Team and one Team can have many Players
        //•	A Player can play at one Position and one Position can be played by many Players
        //•	One Player can play in many Games and in each Game, many Players take part (both collections must be named PlayerStatistics)
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
