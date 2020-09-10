using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            Validator.CheckIfObjectIsNull(player, ExceptionMessages.PlayerCannotBeNull);
            var IsExist = players.FirstOrDefault(x => x.Username == player.Username);
            Validator.CheckIfPlayerNameExist(IsExist, String.Format(ExceptionMessages.PlayerNameAlreadyExist, player.Username));
            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            Validator.CheckIfObjectIsNull(player, ExceptionMessages.PlayerCannotBeNull);
            return players.Remove(player);
        }
    }
}