using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < first[0]; i++)
            {
                s.Push(second[i]);
            }
            for (int i = 0; i < first[1]; i++)
            {
                if(s.Count>0) { s.Pop(); }
            }
            if(s.Contains(first[2])) { Console.WriteLine("true"); }
            else if(s.Count == 0) { Console.WriteLine(0); }
            else { Console.WriteLine(s.Min()); }
        }
    }
}
