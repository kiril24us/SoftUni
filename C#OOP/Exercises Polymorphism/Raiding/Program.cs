using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            List<BaseHero> heroes = new List<BaseHero>();

            while (n != counter)
            {
                string name = Console.ReadLine();
                string typeOfHero = Console.ReadLine();
                BaseHero hero;
                if (typeOfHero == "Druid" || typeOfHero == "Paladin" || 
                    typeOfHero == "Rogue" || typeOfHero == "Warrior")
                {
                    switch (typeOfHero)
                    {
                        case "Druid":
                            hero = new Druid(name);                            
                            heroes.Add(hero);
                            break;
                        case "Paladin":
                            hero = new Paladin(name);                           
                            heroes.Add(hero);
                            break;
                        case "Rogue":
                            hero = new Rogue(name);                            
                            heroes.Add(hero);
                            break;
                        case "Warrior":
                            hero = new Warrior(name);                            
                            heroes.Add(hero);
                            break;
                        default:
                            break;
                    }
                    counter++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;
            foreach (var hero in heroes)
            {
                string response = hero.CastAbility();
                Console.WriteLine(response);
                totalPower += hero.Power;
            }
            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
