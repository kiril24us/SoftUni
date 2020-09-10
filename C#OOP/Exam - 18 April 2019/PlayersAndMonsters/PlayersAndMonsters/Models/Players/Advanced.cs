using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int beginnerHealth = 50;
        public Advanced(ICardRepository cardRepository, string username) : base(cardRepository, username, beginnerHealth)
        {
            
        }
    }
}