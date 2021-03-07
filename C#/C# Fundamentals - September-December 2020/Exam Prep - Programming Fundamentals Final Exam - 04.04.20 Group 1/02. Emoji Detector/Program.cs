using System;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long coolthreshold = 1;
            foreach (char c in input) { if (char.IsDigit(c)) { coolthreshold *= (c - '0'); } }
            Console.WriteLine("Cool threshold: " + coolthreshold);
            string pattern = @"(::|\*\*)([A-Z][a-z]{2,})\1";
            Regex r = new Regex(pattern);
            MatchCollection found = r.Matches(input);
            Console.WriteLine(found.Count + " emojis found in the text. The cool ones are:");
            foreach (Match m in found)
            {
                int coolness = 0;
                foreach (char c in m.Groups[2].Value) { coolness += c; }
                if(coolness > coolthreshold) { Console.WriteLine(m.Value); }
            }
        }
    }
}
