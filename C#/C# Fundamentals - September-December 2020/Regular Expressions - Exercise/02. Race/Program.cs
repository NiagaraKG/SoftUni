using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            List<string> participants = Console.ReadLine().Split(", ").ToList();
            foreach (var name in participants) { distances.Add(name, 0); }
            string namePattern = @"[\W\d]";
            string numberPattern = @"[\WA-Za-z]";
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                List<char> numbers = Regex.Replace(input, numberPattern, "").ToCharArray().ToList();
                int distance = 0;
                foreach (char n in numbers)
                {
                    distance += n-'0';                   
                }
                if(distances.ContainsKey(name)) { distances[name] += distance; }
                input = Console.ReadLine();
            }
            distances = distances.OrderByDescending(x => x.Value).ToDictionary(x=>x.Key, y=>y.Value);
            Console.WriteLine($"1st place: {distances.First().Key}");
            distances.Remove(distances.First().Key);
            Console.WriteLine($"2nd place: {distances.First().Key}");
            distances.Remove(distances.First().Key);
            Console.WriteLine($"3rd place: {distances.First().Key}");
        }
    }
}
