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
        private readonly List<IPlayer> players;

        
        public int Count => this.Players.Count; //•	Count – int – the count of players
        
        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly(); //•	Players – collection of players(unmodifiable)

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }
        //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            bool remove = this.players.Remove(player);
            return remove;
            
        }

        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(x => x.Username == username);
        }
    }
}

