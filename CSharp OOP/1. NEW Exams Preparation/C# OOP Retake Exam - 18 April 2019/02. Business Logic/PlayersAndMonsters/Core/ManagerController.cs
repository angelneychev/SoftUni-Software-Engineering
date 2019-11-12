using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private IPlayerRepository playerRepository;
        private ICardFactory cardFactory;
        private ICardRepository cardRepository;
        private IBattleField battleField;

        public ManagerController(
            IPlayerFactory playerFactory,
            IPlayerRepository playerRepository,
            ICardFactory cardFactory,
            ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerFactory = new PlayerFactory();
            this.playerRepository = new PlayerRepository();
            this.cardFactory = new CardFactory();
            this.cardRepository = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName,username);

            return result;

        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attker, enemy);

            string result = string.Format(ConstantMessages.FightInfo, attker.Health,enemy.Health);

            return result;

        }

        public string Report()
        {
            var sb = new StringBuilder();

            var players = this.playerRepository.Players;

            foreach (var player in players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
            //StringBuilder sb = new StringBuilder();

            //foreach (var player in this.playerRepository.Players)
            //{
            //    sb.AppendLine(player.ToString());

            //    foreach (var card in player.CardRepository.Cards)
            //    {
            //        sb.AppendLine(card.ToString());
            //    }

            //    sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            //}

            //return sb.ToString().TrimEnd();
        }
    }
}
