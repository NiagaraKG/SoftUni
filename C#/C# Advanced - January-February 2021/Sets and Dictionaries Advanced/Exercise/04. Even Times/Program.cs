using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());
                if(counts.ContainsKey(current)) { counts[current]++; }
                else { counts.Add(current, 1); }
            }
            foreach (var item in counts)
            {
                if(item.Value % 2 == 0) { Console.WriteLine(item.Key); }
            }
        }
    }
}
