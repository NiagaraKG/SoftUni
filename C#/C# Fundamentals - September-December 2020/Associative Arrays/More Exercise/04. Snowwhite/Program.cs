using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    public class Characteristic
    {
        public string color;
        public int physics;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> hats = new Dictionary<string, int>();
            Dictionary<Characteristic, string> dwarfs = new Dictionary<Characteristic, string>();
            string[] command = Console.ReadLine().Split(" <:> ");
            while (command[0] != "Once upon a time")
            {
                string name = command[0]; Characteristic c = new Characteristic();
                c.color = command[1]; c.physics = int.Parse(command[2]);
                bool isFound = false;
                foreach (var d in dwarfs)
                {
                    if (d.Value == name && d.Key.color == c.color)
                    {
                        isFound = true;
                        if (d.Key.physics < c.physics) { d.Key.physics = c.physics; }
                    }
                }
                if (!isFound)
                {
                    dwarfs.Add(c, name);
                    if (hats.ContainsKey(c.color)) { hats[c.color]++; }
                    else { hats.Add(c.color, 1); }
                }
                command = Console.ReadLine().Split(" <:> ");
            }
            dwarfs = dwarfs.OrderByDescending(x => x.Key.physics).ThenByDescending(x => hats[x.Key.color])
                                                                 .ToDictionary(x => x.Key, y => y.Value);
            foreach (var d in dwarfs)
            {
                Console.WriteLine($"({d.Key.color}) {d.Value} <-> {d.Key.physics}");
            }
        }
    }
}
