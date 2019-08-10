using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
           Type playerType =  Assembly
               .GetCallingAssembly()
               .GetTypes()
               .FirstOrDefault(x => x.Name.StartsWith(type));

         IPlayer player = (IPlayer) Activator.CreateInstance(playerType,new CardRepository(), username);
         return player;
        }
    }
}
