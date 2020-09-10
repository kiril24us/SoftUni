using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController(IPlayerRepository playerRepository, 
                                 IPlayerFactory playerFactory, 
                                 ICardFactory cardFactory,
                                 ICardRepository cardRepository,
                                 IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }
         
        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username); 
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);
            battleField.Fight(attacker, enemy);
            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }      

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo,player.Username,player.Health,player.CardRepository.Cards.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));                    
                }
                sb.AppendLine(String.Format(ConstantMessages.DefaultReportSeparator));
            }
            return sb.ToString().TrimEnd();
        }      
    }
}
