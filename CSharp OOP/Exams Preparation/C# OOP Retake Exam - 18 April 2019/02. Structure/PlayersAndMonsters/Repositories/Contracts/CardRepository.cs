using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {

            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            bool cardExists = this.cards.Any(x => x.Name == card.Name);
            if (cardExists)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            bool isRemove = this.cards.Remove(card);

            return isRemove;
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(x => x.Name == name);
        }
    }
}
