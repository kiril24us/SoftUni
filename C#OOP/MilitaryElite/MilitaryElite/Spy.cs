using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class Spy : Soldier, ISpy
	{
		public Spy(string firstName, string lastName, string id, int codeNumber)
			: base(firstName, lastName, id)
		{
			CodeNumber = codeNumber;
		}
		public int CodeNumber { get; private set; }

		public override string ToString()
		{
			return $"Name: {FirstName} {LastName} Id: {Id} Code Number: {CodeNumber:f2}";
		}
	}
}
