using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string wordsPattern = @"(@|#)([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";
            Regex r = new Regex(wordsPattern);
            MatchCollection found = r.Matches(text);
            if (found.Count == 0) { Console.WriteLine("No word pairs found!"); }
            else { Console.WriteLine(found.Count + " word pairs found!"); }
            List<string> pairs = new List<string>();
            foreach (Match m in found)
            {
                string first = m.Groups[2].Value;
                char[] second = m.Groups[3].Value.ToCharArray();
                Array.Reverse(second);
                if (first == string.Join("", second))
                {
                    Array.Reverse(second);
                    string pair = first + " <=> " + string.Join("", second);  
                    pairs.Add(pair); 
                }
            }
            if (pairs.Count == 0) { Console.WriteLine("No mirror words!"); }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", pairs));
            }
        }
    }
}
