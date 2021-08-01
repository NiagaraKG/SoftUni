using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> collection = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<string> b = new Box<string>(Console.ReadLine());
                collection.Add(b);
            }
            Box<string> compateTo = new Box<string>(Console.ReadLine());
            Console.WriteLine(Count(collection, compateTo));
        }
        public static int Count<T>(List<T> collection, T compareTo) where T : IComparable
        {
            int br = 0;
            foreach (var item in collection) { if (item.CompareTo(compareTo) == 1) { br++; } }
            return br;
        }
    }
}
