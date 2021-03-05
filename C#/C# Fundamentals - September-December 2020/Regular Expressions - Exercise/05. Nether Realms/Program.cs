using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> all = new List<Demon>();
            string numPattern = @"[+-]?[0-9]+\.?[0-9]*";
            Regex numRegex = new Regex(numPattern);

            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in input)
            {
                string filter = "0123456789+-*/.";
                int health = name.Where(c=> !filter.Contains(c)).Sum(c=>c);

                double damage = 0;
                MatchCollection numMatches = numRegex.Matches(name);
                foreach (Match m in numMatches)
                {
                    damage += double.Parse(m.Value);
                }
                foreach (var c in name)
                {
                    if(c == '*') { damage *= 2.0; }
                    else if(c == '/') { damage /= 2.0; }
                }

                all.Add(new Demon { Name = name, Health = health, Damage = damage });
            }
            all = all.OrderBy(d => d.Name).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, all));
        }
    }
}
