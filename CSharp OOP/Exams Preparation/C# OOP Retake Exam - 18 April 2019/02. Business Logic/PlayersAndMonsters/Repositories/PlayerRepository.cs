using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            this.playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => this.playersByName.Count;
        public IReadOnlyCollection<IPlayer> Players => this.playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException ($"Player cannot be null");
            }

            if (this.playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException ($"Player {player.Username} already exists!");
            }
            this.playersByName.Add(player.Username,player);

        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null!");
            }
            bool hasRemoved = this.playersByName.Remove(player.Username); // връща true или false

            return hasRemoved;
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (this.playersByName.ContainsKey(username))
            {
                player = this.playersByName[username];
            }

            return player;
        }
    }
}
