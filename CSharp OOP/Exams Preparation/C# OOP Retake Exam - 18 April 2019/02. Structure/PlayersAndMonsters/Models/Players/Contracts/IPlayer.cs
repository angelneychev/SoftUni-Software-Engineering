namespace PlayersAndMonsters.Models.Players.Contracts
{
    using PlayersAndMonsters.Repositories.Contracts;

    public interface IPlayer
    {
        ICardRepository CardRepository { get; }

        string Username { get; }

        int Health { get; set; }

        bool IsDead { get; }
       // string username { get; set; }

        void TakeDamage(int damagePoints);
    }
}
