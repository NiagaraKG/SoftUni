using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<double>> collection = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<double> b = new Box<double>(double.Parse(Console.ReadLine()));
                collection.Add(b);
            }
            Box<double> compateTo = new Box<double>(double.Parse(Console.ReadLine()));
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
