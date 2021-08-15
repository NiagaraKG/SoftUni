using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> unique = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < line.Length; j++) { unique.Add(line[j]); }
            }
            Console.WriteLine(string.Join(" ", unique));
        }
    }
}
