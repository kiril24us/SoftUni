using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class Soldier : ISoldier
	{
		public Soldier(string firstName, string lastName, string id)
		{
			FirstName = firstName;
			LastName = lastName;
			Id = id;
		}
		public string Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

        public override string ToString()
        {
			return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
