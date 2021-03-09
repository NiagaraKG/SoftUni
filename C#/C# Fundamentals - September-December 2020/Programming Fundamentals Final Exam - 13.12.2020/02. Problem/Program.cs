using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"([*@])([A-Z][a-z]{2,})\1(: )(\[([A-Za-z])\]\|)(\[([A-Za-z])\]\|)(\[([A-Za-z])\]\|)";
                Regex r = new Regex(pattern);
                Match m = r.Match(input);
                if(!m.Success) { Console.WriteLine("Valid message not found!"); }
                else
                {
                    string found = m.Value;
                    string end = input.Substring(input.Length - found.Length);
                    if (end != found) { Console.WriteLine("Valid message not found!"); }
                    else 
                    {
                        string tag = m.Groups[2].Value;
                        List<int> values = new List<int>();
                        char c = char.Parse(m.Groups[5].Value);
                        values.Add(c);
                        c = char.Parse(m.Groups[7].Value);
                        values.Add(c);
                        c = char.Parse(m.Groups[9].Value);
                        values.Add(c);
                        Console.WriteLine(tag + ": " + string.Join(" ", values));
                    }
                }
            }
        }
    }
}
