using System;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        public ICardRepository CardRepository { get; }                                                                              

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public string Username
        {
            get => this.username;
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, ExceptionMessages.PlayersUsername);
                this.username = value;
            }

        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.CheckIfValueIsBelow0(value, ExceptionMessages.PlayersHealth);
                this.health = value;
            }

        }

        public bool IsDead => this.health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.CheckIfValueIsBelow0(damagePoints, ExceptionMessages.CardDamagePoints);
            if (health >= damagePoints)
            {
                health -= damagePoints;
            }
            else
            {
                health = 0;
            }
        }
    }
}