using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    public class Citizen : IResident, IPerson
    {
        public string Name { get; private set; }

        string IResident.Name { get; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        void IPerson.GetName(string name)
        {
            Console.WriteLine(name);
        }

        void IResident.GetName(string name)
        {
            Console.WriteLine($"Mr / Ms / Mrs {name}");            
        }
    }
}
