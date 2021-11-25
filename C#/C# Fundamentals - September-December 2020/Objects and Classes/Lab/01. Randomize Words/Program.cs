using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Random r = new Random();
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                int index = r.Next(0, words.Count);
                words[i] = words[index];
                words[index] = word;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
