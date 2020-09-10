using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public interface IMissions
	{
		public string CodeName { get; }

		public string State { get; }

		public void CompleteMission()
		{

		}
	}
}
