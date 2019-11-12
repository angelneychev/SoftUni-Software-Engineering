using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values.ToList();


        public void Add(ICard card)
        {

            if (card == null)
            {
                throw new ArgumentException ($"Card cannot be null!");
            }

            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException ($"Card {card.Name} already exists!");
            }
            this.cardsByName.Add(card.Name, card); // речник!!!!!!!
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException ($"Card cannot be null!");
            }
            bool hasRemoved = this.cardsByName.Remove(card.Name); // връща true или false
            return hasRemoved;
        }
        public ICard Find(string name)
        {

            ICard card = null;

            if (cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }
            return card;
        }
    }
}
