using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando : ISpecializedSoldier
    {
        public IReadOnlyCollection<IMissions> Missions { get; }

        void AddMission(IMissions mission);
    }
}
