using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> counts = new SortedDictionary<char, int>();
            char[] characters = Console.ReadLine().ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                if (counts.ContainsKey(characters[i])) { counts[characters[i]]++; }
                else { counts.Add(characters[i], 1); }
            }
            foreach (var c in counts) { Console.WriteLine($"{c.Key}: {c.Value} time/s"); }
        }
    }
}
