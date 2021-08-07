using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> s = new Queue<int>();
            for (int i = 0; i < first[0]; i++)
            {
                s.Enqueue(second[i]);
            }
            for (int i = 0; i < first[1]; i++)
            {
                if (s.Count > 0) { s.Dequeue(); }
            }
            if (s.Contains(first[2])) { Console.WriteLine("true"); }
            else if (s.Count == 0) { Console.WriteLine(0); }
            else { Console.WriteLine(s.Min()); }
        }
    }
}
