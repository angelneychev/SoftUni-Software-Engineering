using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.StartsWith(type));

            if (cardType == null)
            {
                throw new ArgumentException("Card of this type does not exists!");
            }

            var card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
