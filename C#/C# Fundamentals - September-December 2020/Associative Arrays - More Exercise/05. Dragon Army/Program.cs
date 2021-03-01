using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army
{
    class Dragon
    {
        public string name;
        public double damage = 45;
        public double health = 250;
        public double armor = 10;

        public Dragon(string[] stats)
        {
            this.name = stats[1];
            if (stats[2] != "null") { this.damage = double.Parse(stats[2]); }
            if (stats[3] != "null") { this.health = double.Parse(stats[3]); }
            if (stats[4] != "null") { this.armor = double.Parse(stats[4]); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] stats = Console.ReadLine().Split();
                Dragon current = new Dragon(stats);
                if (dragons.ContainsKey(stats[0])) 
                {
                    bool isFound = false;
                    for (int d = 0; d < dragons[stats[0]].Count; d++)
                    {
                        if(dragons[stats[0]][d].name == current.name)
                        {
                            isFound = true;
                            dragons[stats[0]][d] = current;
                        }
                    }
                    if (!isFound) { dragons[stats[0]].Add(current); }
                }
                else { dragons.Add(stats[0], new List<Dragon> { current}); }
            }
            foreach (var t in dragons)
            {
                double damage = t.Value.Average(x=>x.damage);
                double health = t.Value.Average(x => x.health);
                double armor = t.Value.Average(x => x.armor);
                Console.WriteLine($"{t.Key}::({damage:f2}/{health:f2}/{armor:f2})");
                foreach (var d in t.Value.OrderBy(x=>x.name))
                {
                    Console.WriteLine($"-{d.name} -> damage: {d.damage}, health: {d.health}, armor: {d.armor}");
                }
            }
        }
    }
}
