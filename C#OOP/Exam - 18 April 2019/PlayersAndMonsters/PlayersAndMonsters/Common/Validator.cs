using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfValueIsBelow0(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfOneOfThePlayersIsDead(IPlayer attackPlayer, IPlayer enemyPlayer, string message)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfPlayerIsBeginner(IPlayer attackPlayer)
        {
            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                var cardsOfPlayer = attackPlayer.CardRepository.Cards;
                foreach (var card in cardsOfPlayer)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        public static void CheckIfObjectIsNull(object @object, string message)
        {
            if (@object == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfPlayerNameExist(object @object, string message)
        {
            if (@object != null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
