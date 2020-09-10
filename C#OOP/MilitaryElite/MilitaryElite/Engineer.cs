using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(string firstName, string lastName, string id, decimal salary, string corps)
            : base(firstName, lastName, id, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => repairs;


        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Repairs");
            foreach (var repair in repairs)
            {
                sb.AppendLine(repair.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
