using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class ManagerController : IManagerController
    {
        
        private readonly IPlayerFactory playerFactory;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardFactory cardFactory;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;



        public ManagerController(
            IPlayerFactory playerFactory,
            IPlayerRepository playerRepository, 
            ICardFactory cardFactory, 
            ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            string result = $"Successfully added player of type {type} with username: {username}";

            return result;

        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            string result = $"Successfully added card of type {type}Card with name: {name}";

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);
            
            player.CardRepository.Add(card);

            string result = $"Successfully added card: {card.Name} to user: {player.Username}";
            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
