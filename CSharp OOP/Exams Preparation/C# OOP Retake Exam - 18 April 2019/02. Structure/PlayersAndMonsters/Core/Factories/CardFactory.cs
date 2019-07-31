using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private const string Suffix = "Card";
        public ICard CreateCard(string type, string name)
        {
            Type typeCard = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + Suffix);

            //if (typeCard == null)
            //{
            //    throw new ArgumentException("Card of this type does not exists!");
            //}
            ICard card = (ICard)Activator.CreateInstance(typeCard,name);

            return card;
        }

    }
}