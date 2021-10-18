using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        public static object Redex { get; private set; }

        static void Main(string[] args)
        {
            List<string> parts = Console.ReadLine().Split("|").ToList();
            string patternCapitals = @"([$#%*&])([A-Z]+)\1";
            Regex caps = new Regex(patternCapitals);
            string capitals = caps.Match(parts[0]).Groups[2].Value;
            string patternLenghts = @"(\d{2}):(\d{2})";
            Regex l = new Regex(patternLenghts);
            MatchCollection matchesLenghts = l.Matches(parts[1]);
            Dictionary<char, int> lenghts = new Dictionary<char, int>();
            foreach (char cap in capitals)
            {
                foreach (Match item in matchesLenghts)
                {
                    char c = (char)int.Parse(item.Groups[1].Value);
                    string secondPart = item.Groups[2].Value;
                    if (secondPart[0] == '0') { secondPart.Remove(0, 1); }
                    int lenght = int.Parse(secondPart) + 1;
                    if (cap == c && !lenghts.ContainsKey(c)) { lenghts.Add(c, lenght); }
                }
            }
            List<string> words = parts[2].Split().ToList();
            foreach (var pair in lenghts)
            {
                foreach (var word in words) 
                { if (word.Length == pair.Value && word[0] == pair.Key) { Console.WriteLine(word); } }
            }
        }
    }
}
