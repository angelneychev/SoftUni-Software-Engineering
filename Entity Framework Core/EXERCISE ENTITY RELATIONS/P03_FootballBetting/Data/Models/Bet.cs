namespace P03_FootballBetting.Data.Models
{
    using System;
    using P03_FootballBetting.Data.Models.Enum;
    public class Bet
    {
        //•	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId

        //•	Many Bets can be placed on one Game, but a Bet can be only on one Game
        //•	Each bet for given game must have Prediction result
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

    }
}
