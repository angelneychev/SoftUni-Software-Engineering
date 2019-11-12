using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;


namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IDictionary<string,ICard> cardByName;

        public CardRepository()
        {
            this.cardByName = new Dictionary<string, ICard>();
        }


        public int Count => this.Cards.Count; //•	Count – int – the count of cards

        public IReadOnlyCollection<ICard> Cards => this.cardByName.Values.ToList(); //•	Cards – collection of cards (unmodifiable)


        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            if (this.cardByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cardByName.Add(card.Name,card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            bool remove = this.cardByName.Remove(card.Name);
            return remove;
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cardByName.ContainsKey(name))
            {
                card = this.cardByName[name];
            }
            return card;
        }
    }
}
