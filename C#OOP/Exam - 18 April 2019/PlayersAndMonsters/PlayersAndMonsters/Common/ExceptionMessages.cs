using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public class ExceptionMessages
    {
        public const string PlayersUsername = "Player's username cannot be null or an empty string.";

        public const string PlayersHealth = "Player's username cannot be null or an empty string.";

        public const string CardDamagePoints = "Damage points cannot be less than zero.";

        public const string CardName = "Card's name cannot be null or an empty string.";

        public const string CardHealthPoints = "Card's HP cannot be less than zero.";

        public const string PlayerIsDead = "Player is dead!";

        public const string PlayerCannotBeNull = "Player cannot be null";

        public const string PlayerAlreadyExist = "Player cannot be null";

        public const string PlayerNameAlreadyExist = "Player {0} already exists!";

        public const string CardCannotBeNull = "Card cannot be null";

        public const string CardNameAlreadyExist = "Card {0} already exists!";
        
    }
}
