using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1) { s.Push(input[1]); }
                else if (input[0] == 2) { if (s.Count > 0) { s.Pop(); } }
                else if (input[0] == 3) { if (s.Count > 0) { Console.WriteLine(s.Max()); } }
                else if (input[0] == 4) { if (s.Count > 0) { Console.WriteLine(s.Min()); } }
            }
            Console.WriteLine(string.Join(", ", s));
        }
    }
}
