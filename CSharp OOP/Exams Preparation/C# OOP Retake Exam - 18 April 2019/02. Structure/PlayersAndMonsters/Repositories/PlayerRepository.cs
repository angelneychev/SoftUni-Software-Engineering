using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    class PlayerRepository : IPlayerRepository
    {
        //•	Players – collection of players (unmodifiable)
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        //•	Count – int – the count of players
        public int Count => this.Players.Count;
        //•	Players – collection of players (unmodifiable)
        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            //•	If the player is null, throw an ArgumentException with message "Player cannot be null".

            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            bool playerExists = this.players.Any(x => x.Username == player.Username);

            if (playerExists)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            bool isRemove = this.players.Remove(player);

            return isRemove;
        }

        //Returns a player with that username.
        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(x => x.Username == username);
        }
    }
}
