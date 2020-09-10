using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(x => x.GetType() == typeof(Terrorist)).ToArray();
            var counterTerrorists = players.Where(x => x.GetType() == typeof(CounterTerrorist)).ToArray();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                Shooting(terrorists, counterTerrorists);

                Shooting(counterTerrorists, terrorists);
            }

            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }

        private static void Shooting(IPlayer[] players, IPlayer[] players2)
        {
            //ToDO: check
            foreach (var player in players.Where(x => x.IsAlive))
            {
                foreach (var player2 in players2.Where(x => x.IsAlive))
                {
                    player2.TakeDamage(player.Gun.Fire());
                }
            }
        }
    }
}
