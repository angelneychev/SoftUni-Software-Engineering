using System;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository; //??????????????????????
        }
        //CardRepository – repository of all user's cards.
        public ICardRepository CardRepository { get;}


        //Username – string (If the username is null or empty, throw an ArgumentException with message "Player's username cannot be null or an empty string. ")
        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                this.username = value;
            }
        }
        //Health – the health of а player(if the health is below 0, throw an ArgumentException with message "Player's health bonus cannot be less than zero. ")
        public int Health
        {
            get => this.health;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                this.health = value;
            }
        }
        //IsDead – calculated property which returns bool.
        public bool IsDead => this.health <= 0;


        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0) 
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints >=0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;
            }
        }
    }
}
