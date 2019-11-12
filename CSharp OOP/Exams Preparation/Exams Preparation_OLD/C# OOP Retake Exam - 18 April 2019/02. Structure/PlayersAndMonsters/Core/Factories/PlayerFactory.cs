using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.StartsWith(type));

           // var repository = new CardRepository();

            var player = (IPlayer)Activator.CreateInstance(playerType, new CardRepository(), username);

            return player;
        }
    }
}
