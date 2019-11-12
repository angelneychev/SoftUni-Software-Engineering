using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;


namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;


        public int Count => this.Cards.Count; //•	Count – int – the count of cards

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly(); //•	Cards – collection of cards (unmodifiable)


        public void Add(ICard card)
        {
            if (cards == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (cards.Contains(card))
            {
                throw new ArgumentException($"Player {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (cards == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            bool remove = this.cards.Remove(card);
            return remove;
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(x => x.Name == name);
        }
    }
}
