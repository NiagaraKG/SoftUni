using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();            
            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();
            for (int i = 0; i < n[0]; i++) { first.Add(Console.ReadLine()); }
            for (int i = 0; i < n[1]; i++) { second.Add(Console.ReadLine()); }
            foreach (var item in first)
            {
                if(second.Contains(item)) { Console.Write(item + " "); }
            }
        }
    }
}
