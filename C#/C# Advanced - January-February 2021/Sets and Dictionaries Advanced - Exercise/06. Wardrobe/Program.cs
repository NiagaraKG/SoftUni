using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                input = input.Skip(1).ToArray();
                if (!wardrobe.ContainsKey(color)) { wardrobe.Add(color, new Dictionary<string, int>()); }
                foreach (string item in input)
                {
                    if (!wardrobe[color].ContainsKey(item)) { wardrobe[color].Add(item, 0); }
                    wardrobe[color][item]++;
                }
            }
            string[] search = Console.ReadLine().Split();            
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == search[0] && cloth.Key == search[1]) { Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)"); }
                    else { Console.WriteLine($"* {cloth.Key} - {cloth.Value}"); }
                }
            }
        }
    }
}
