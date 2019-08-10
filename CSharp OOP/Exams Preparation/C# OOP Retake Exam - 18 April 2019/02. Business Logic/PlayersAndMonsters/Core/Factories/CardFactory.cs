using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cartType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name.StartsWith(type));

            ICard card = (ICard) Activator.CreateInstance(cartType, name);

            return card;
        }
    }
}
