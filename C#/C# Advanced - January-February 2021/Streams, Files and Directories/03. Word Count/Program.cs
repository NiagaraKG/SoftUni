using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] search = File.ReadAllLines(Path.Combine("..","..","..","words.txt"));
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (string word in search) { counts.Add(word.ToLower(), 0); }
            string[] text = File.ReadAllText(Path.Combine("..", "..", "..", "text.txt")).ToLower().Split(new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in text) { if (counts.ContainsKey(word)) { counts[word]++; } }
            counts = counts.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            List<string> output = counts.Select(x => $"{x.Key} - {x.Value}").ToList();
            File.WriteAllLines(Path.Combine("..", "..", "..", "actualResult.txt"), output);
        }
    }
}
