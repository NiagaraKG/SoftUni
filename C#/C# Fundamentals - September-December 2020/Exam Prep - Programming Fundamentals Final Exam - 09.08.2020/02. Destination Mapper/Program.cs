using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            Regex r = new Regex(pattern);
            MatchCollection matches = r.Matches(input);
            List<string> destinations = new List<string>();
            foreach (Match m in matches) { destinations.Add(m.Groups[2].Value); }
            Console.WriteLine("Destinations: " + string.Join(", ", destinations));
            int points = 0;
            foreach (var d in destinations) { points += d.Length; }
            Console.WriteLine("Travel Points: " + points);
        }
    }
}
