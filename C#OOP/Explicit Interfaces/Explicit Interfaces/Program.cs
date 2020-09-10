using System;

namespace Explicit_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInformation = input.Split();

                var citizen = new Citizen();
                IPerson person = citizen;
                person.GetName(citizenInformation[0]);
                IResident resident = citizen;
                resident.GetName(citizenInformation[0]);
            }
        }
    }
}
