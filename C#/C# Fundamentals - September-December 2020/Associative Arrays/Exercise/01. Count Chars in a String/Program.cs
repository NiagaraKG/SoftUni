using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray().Where(x=> x!= ' ').ToArray();
            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            foreach (var item in input)
            {
                if(!occurrences.ContainsKey(item)) { occurrences.Add(item, 0); }
                occurrences[item]++;
            }
            foreach (var item in occurrences)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
