using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public abstract class BattleField : IBattleField
    {
        private const int DefaultDamagePointsForBeginner = 30;
        private const int DefaultHealthPointsForBeginner = 40;


        // That's the most interesting method. 
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        { 
        // If one of the users is dead, throw new ArgumentException with message "Player is dead!"

        if (attackPlayer.IsDead || enemyPlayer.IsDead)
        {
            throw new ArgumentException("Player is dead!");
        }

        // If the player is a beginner, increase his health with 40 points and increase all damage points of all cards or the user with 30.
        if (attackPlayer.GetType() == typeof(Beginner))
        {
            attackPlayer.Health += DefaultHealthPointsForBeginner;

            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                card.DamagePoints += DefaultDamagePointsForBeginner;
            }
        }

        if (enemyPlayer.GetType() == typeof(Beginner))
        {
            enemyPlayer.Health += DefaultHealthPointsForBeginner;

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                card.DamagePoints += DefaultDamagePointsForBeginner;
            }
        }

// Before the fight, both players get bonus health points from their deck.
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            // Attacker attacks first and after that the enemy attacks.If one of the players is dead you should stop the fight.
            while (true)
            {
                var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }

        }
    }
}
