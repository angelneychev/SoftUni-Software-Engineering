using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }


        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Player's username cannot be null or an empty string. ");
                }
                this.username = value;
            }

        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }
        public bool IsDead => this.health <= 0;
        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException($"Damage points cannot be less than zero.");
            }
          //this.Health = Math.Max(this.health- damagePoints, 0)

            int newHealth = this.Health - damagePoints;
            //this.Health = newHealth < 0 ? 0 : newHealth;
            if (newHealth < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = newHealth;
            }
        }

        //public override string ToString()
        //{
        //    return string.Format(ConstantMessages.PlayerReportInfo,
        //        this.Username, 
        //        this.Health, 
        //        this.CardRepository);
        //}
    }
}