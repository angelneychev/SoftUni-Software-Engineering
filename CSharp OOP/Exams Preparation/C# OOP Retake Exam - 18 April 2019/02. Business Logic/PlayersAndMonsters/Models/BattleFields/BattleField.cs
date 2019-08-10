using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {

            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException($"Player is dead!");
            }

            if (attackPlayer is Beginner) // това казва ако атакера е бегинър
            {
                attackPlayer.Health += 40;
                foreach (ICard card in attackPlayer.CardRepository.Cards)
                    //all cards for the user with 30
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer is Beginner) // това казва ако енеми е бегинър
            {
                enemyPlayer.Health += 40;
                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                    //all cards for the user with 30
                {
                    card.DamagePoints += 30;
                }
            }

            int attackPlayerBonusHealth = attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            attackPlayer.Health += attackPlayerBonusHealth;

            int enemyPlayerBonusHealth = enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayerBonusHealth;


            int attackPlayerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
            int enemyPlayerDamage = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyPlayerDamage);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
