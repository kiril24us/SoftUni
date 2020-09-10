using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;

namespace MilitaryElite
{
    class Program
    {
        static List<ISoldier> army;

        static void Main()
        {
            
            army = new List<ISoldier>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split();
                string typeOfSoldier = commands[0];
                string id = commands[1];
                string firstName = commands[2];
                string lastName = commands[3];
                decimal salary = decimal.Parse(commands[4], CultureInfo.InvariantCulture);

                if (typeOfSoldier == "Private")
                {
                    Private @private = new Private(firstName, lastName, id, salary);
                    army.Add(@private);
                }
                if (typeOfSoldier == "LieutenantGeneral")
                {
                    LieutenantGeneral leutenant = new LieutenantGeneral(firstName, lastName, id, salary);
                    string[] privatesIds = commands.Skip(5).ToArray();
                    foreach (var privateId in privatesIds)
                    {
                        var @private = army.FirstOrDefault(x => x.Id == privateId);
                        leutenant.AddPrivate(@private);
                    }
                    army.Add(leutenant);
                }

                if (typeOfSoldier == "Engineer")
                {
                    try
                    {
                        string corps = commands[5];
                        string[] parts = commands.Skip(6).ToArray();
                        IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);
                        AddRepairs(engineer, parts);
                        army.Add(engineer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                   
                }

                if (typeOfSoldier == "Commando")
                {
                    try
                    {
                        string corps = commands[5];
                        string[] missions = commands.Skip(6).ToArray();
                        ICommando commando = new Commando(firstName, lastName, id, salary, corps);
                        AddMissions(commando, missions);
                        army.Add(commando);
                    }
                    catch (InvalidStateException)
                    {
                        continue;
                    }
                }

                if (typeOfSoldier == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                }
                input = Console.ReadLine();
            }
            PrintOutput();
        }

        private static void AddMissions(ICommando commando, string[] missions)
        {
            for (int i = 0; i < missions.Length; i += 2)
            {
                string codeName = missions[i];
                string state = missions[i + 1];
                IMissions mission = new Mission(codeName, state);
                commando.AddMission(mission);
            }
        }

        private static void AddRepairs(IEngineer engineer, string[] parts)
        {
            for (int i = 0; i < parts.Length; i+=2)
            {
                string partName = parts[i];
                int hour = int.Parse(parts[i + 1]);
                IRepair repair = new Repair(partName, hour);
                engineer.AddRepair(repair);
            }
        }

        private static void PrintOutput()
        {
            foreach (var soldier in army)
            {
                Type type = soldier.GetType();
                object actual = Convert.ChangeType(soldier, type);
                Console.WriteLine(actual.ToString());
            }
        }
    }
}
