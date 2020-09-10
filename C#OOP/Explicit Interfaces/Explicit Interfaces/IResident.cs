using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    public interface IResident
    {
        public string Name { get; }

        public string Country { get; }

        void GetName(string name);
    }
}
