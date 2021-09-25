using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!synonyms.ContainsKey(word)) { synonyms.Add(word, new List<string>()); }
                synonyms[word].Add(synonym);
            }
            foreach (var item in synonyms)
            {
                Console.Write(item.Key + " - ");
                Console.WriteLine(string.Join(", ", item.Value));
            }
        }
    }
}
