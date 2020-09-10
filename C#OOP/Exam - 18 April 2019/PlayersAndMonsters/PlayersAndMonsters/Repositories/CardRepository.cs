using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }
        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            Validator.CheckIfObjectIsNull(card, ExceptionMessages.CardCannotBeNull);
            var IsExist = cards.FirstOrDefault(x => x.Name == card.Name);
            Validator.CheckIfPlayerNameExist(IsExist, String.Format(ExceptionMessages.CardNameAlreadyExist, card.Name));
            cards.Add(card);
        }

        public ICard Find(string username)
        {
            return cards.FirstOrDefault(x => x.Name == username);
        }

        public bool Remove(ICard card)
        {
            Validator.CheckIfObjectIsNull(card, ExceptionMessages.PlayerCannotBeNull);
            return cards.Remove(card);
        }
    }
}