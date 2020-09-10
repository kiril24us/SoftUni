using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class SpecialisedSoldier : Private, ISpecializedSoldier
	{
		private string corps;
        public SpecialisedSoldier(string firstName, string lastName, string id, decimal salary, string corps)
			: base (firstName, lastName, id, salary)
        {
			Corps = corps;
        }
		public string Corps
		{
			get => corps;

			set
			{
				if (value == "Airforces" || value == "Marines")
				{
					corps = value;
				}

				else
				{
					throw new ArgumentException("Invalid cors!");
				}
			}
		}

        public override string ToString()
        {			
            return base.ToString() + Environment.NewLine + $"Corps: {corps }";

		}
    }
}
