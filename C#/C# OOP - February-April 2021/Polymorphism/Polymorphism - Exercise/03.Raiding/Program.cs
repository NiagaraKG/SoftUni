using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid": heroes.Add(new Druid(name)); break;
                    case "Paladin": heroes.Add(new Paladin(name)); break;
                    case "Rogue": heroes.Add(new Rogue(name)); break;
                    case "Warrior": heroes.Add(new Warrior(name)); break;
                    default: Console.WriteLine("Invalid hero!"); break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine()), groupPower = 0;
            foreach (var h in heroes)
            {
                Console.WriteLine(h.CastAbility());
                groupPower += h.Power;
            }
            if (groupPower >= bossPower) { Console.WriteLine("Victory!"); }
            else { Console.WriteLine("Defeat..."); }
        }
    }
}
