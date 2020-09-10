using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class Commando : SpecialisedSoldier, ICommando
	{
		private List<IMissions> missions;
		public Commando(string firstName, string lastName, string id, decimal salary, string corps)
			: base(firstName, lastName, id, salary, corps)
		{
			missions = new List<IMissions>();
		}
		

		public IReadOnlyCollection<IMissions> Missions => missions;

        public void AddMission(IMissions mission)
        {
			missions.Add(mission);
        }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(base.ToString()).AppendLine("Missions");
			foreach (var mission in missions)
			{
				sb.AppendLine(mission.ToString().TrimEnd());
			}
			return sb.ToString().TrimEnd();
		}
	}
}
