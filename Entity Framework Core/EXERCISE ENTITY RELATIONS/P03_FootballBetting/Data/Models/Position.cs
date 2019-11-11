namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Position
    {
        //•	Position – PositionId, Name
        //•	A Player can play at one Position and one Position can be played by many Players
        public int PositionId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
