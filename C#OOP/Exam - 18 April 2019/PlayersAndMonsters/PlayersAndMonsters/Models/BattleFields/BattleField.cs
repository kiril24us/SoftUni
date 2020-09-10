using System;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            Validator.CheckIfOneOfThePlayersIsDead(attackPlayer, enemyPlayer, ExceptionMessages.PlayerIsDead);

            Validator.CheckIfPlayerIsBeginner(attackPlayer);
            Validator.CheckIfPlayerIsBeginner(enemyPlayer);
            AddingAdditionalHealthPoints(attackPlayer);
            AddingAdditionalHealthPoints(enemyPlayer);
            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {                
                TakeDamage(attackPlayer, enemyPlayer);
                if (!enemyPlayer.IsDead)
                {
                    TakeDamage(enemyPlayer, attackPlayer);
                }                
            }
        }

        private static void TakeDamage(IPlayer attacker, IPlayer attackedPlayer)
        {
            attackedPlayer.TakeDamage(attacker.CardRepository.Cards.Select(x => x.DamagePoints).Sum());
        }

        private static void AddingAdditionalHealthPoints(IPlayer attackPlayer)
        {
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
        }

    }
}