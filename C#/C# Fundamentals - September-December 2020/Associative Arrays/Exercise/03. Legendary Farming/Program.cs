using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            while (keyMaterials["shards"] < 250 && keyMaterials["fragments"] < 250 && keyMaterials["motes"] < 250)
            {
                string[] materials = Console.ReadLine().ToLower().Split();
                for (int i = 1; i < materials.Length; i += 2)
                {
                    if (materials[i] == "shards" || materials[i] == "fragments" || materials[i] == "motes")
                    {
                        keyMaterials[materials[i]] += int.Parse(materials[i - 1]);
                    }
                    else if (junk.ContainsKey(materials[i]))
                    {
                        junk[materials[i]] += int.Parse(materials[i - 1]);
                    }
                    else { junk.Add(materials[i], int.Parse(materials[i - 1])); }
                    if(keyMaterials["shards"] >= 250 || keyMaterials["fragments"] >= 250 || keyMaterials["motes"] >= 250) { break; }
                }
            }
            if (keyMaterials["fragments"] >= 250)
            { keyMaterials["fragments"] -= 250; Console.WriteLine("Valanyr obtained!"); }
            if (keyMaterials["motes"] >= 250)
            { keyMaterials["motes"] -= 250; Console.WriteLine("Dragonwrath obtained!"); }
            if (keyMaterials["shards"] >= 250)
            { keyMaterials["shards"] -= 250; Console.WriteLine("Shadowmourne obtained!"); }
            keyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                                                                       .ToDictionary(a=>a.Key, a=>a.Value);
            foreach (var item in keyMaterials)
            { Console.WriteLine(item.Key + ": " + item.Value); }
            junk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in junk)
            { Console.WriteLine(item.Key + ": " + item.Value); }
        }
    }
}
