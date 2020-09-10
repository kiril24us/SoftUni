using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
	public class Mission : IMissions
	{
        public Mission(string codeName, string state)
        {
			CodeName = codeName;
			State = state;
        }
		public string CodeName { get; set; }

        public string State
        {

            get => State;

            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    State = value;
                }

                else
                {
                    throw new InvalidStateException();
                }
            }
        }

        public void CompleteMission()
		{
			
		}

		public override string ToString()
		{
			return $"Code Name: {CodeName} State: {State}";
		}
	}
}
