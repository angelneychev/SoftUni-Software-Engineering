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
        private readonly IDictionary<string,IPlayer> playerByName;

        public PlayerRepository()
        {
            this.playerByName = new Dictionary<string, IPlayer>();
        }
        public int Count => this.Players.Count; //•	Count – int – the count of players
        
        public IReadOnlyCollection<IPlayer> Players => this.playerByName.Values.ToList(); //•	Players – collection of players(unmodifiable)

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            } 
            //  var playerExists = this.players.Any(x => x.Username == player.Username);
            if (this.playerByName.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.playerByName.Add(player.Username,player);
        }
        //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            bool remove = this.playerByName.Remove(player.Username);
            return remove;
            
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;
            if (this.playerByName.ContainsKey(username))
            {
                player = this.playerByName[username];
            }

            return player;
        }
    }
}

