using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISpecializedSoldier : IPrivate
    {
        public string Corps { get; set; }
    }
}
