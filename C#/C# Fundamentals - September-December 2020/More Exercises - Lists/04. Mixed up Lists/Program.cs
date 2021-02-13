using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            second.Reverse();
            List<int> merged = new List<int>();
            int max = (first.Count > second.Count) ? 1 : 2;
            int start, end;
            if(max == 1)
            {
                start = first[first.Count - 2];
                end = first.Last();
                first.RemoveAt(first.Count - 1);
                first.RemoveAt(first.Count - 1);
            }
            else
            {
                start = second[second.Count - 2];
                end = second.Last();
                second.RemoveAt(second.Count - 1);
                second.RemoveAt(second.Count - 1);
            }
            if (start > end) { int buf = start; start = end; end = buf; }
            for (int i = 0; i < first.Count; i++)
            {
                merged.Add(first[i]);
                merged.Add(second[i]);
            }
            merged.Sort();            
            List<int> result = new List<int>();
            for (int i = 0; i < merged.Count; i++)
            {
                if(merged[i] > start && merged[i] < end)
                { result.Add(merged[i]);}
            }
            
            Console.WriteLine(String.Join(' ', result));
        }
    }
}
