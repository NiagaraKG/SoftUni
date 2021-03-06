using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string pattern = @"(\D+)(\d+)";
            Regex r = new Regex(pattern);
            MatchCollection matches = r.Matches(input);
            StringBuilder result = new StringBuilder();
            foreach (Match item in matches)
            {
                string text = item.Groups[1].Value;
                int times = int.Parse(item.Groups[2].Value);
                for (int i = 0; i < times; i++) { result.Append(text); }
            }
            List<char> cleared = result.ToString().ToCharArray().Where(x => !char.IsDigit(x)).Distinct().ToList();
            Console.WriteLine("Unique symbols used: " + cleared.Count());
            Console.WriteLine(result);
        }
    }
}
