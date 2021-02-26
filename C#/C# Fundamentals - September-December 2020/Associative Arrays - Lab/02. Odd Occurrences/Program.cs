using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (var item in input)
            {
                if (words.ContainsKey(item)) { words[item]++; }
                else { words.Add(item, 1); }
            }
            foreach (var item in words)
            {
                if (item.Value % 2 == 1) { Console.Write(item.Key + " "); }
            }
        }
    }
}
