using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class LieutenantGeneral : Private, ILieutenantGeneral
	{
		private List<ISoldier> privates;
		public LieutenantGeneral(string firstName, string lastName, string id, decimal salary) : 
			base(firstName, lastName, id, salary)
		{			
			privates = new List<ISoldier>();
		}

		public IReadOnlyCollection<ISoldier> Privates => privates;

        public void AddPrivate(ISoldier @private)
        {
			privates.Add(@private);
        }

        public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(base.ToString()).AppendLine("Privates:");

            foreach (var @private in privates)
            {
				sb.AppendLine($"{@private.ToString().TrimEnd()}");
            }

			return sb.ToString().TrimEnd();
		}
	}
}
