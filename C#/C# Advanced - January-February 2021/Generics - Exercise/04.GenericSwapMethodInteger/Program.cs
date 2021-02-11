using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> collection = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<int> b = new Box<int>(int.Parse(Console.ReadLine()));
                collection.Add(b);
            }
            int[] positions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            collection = Swap(collection, positions[0], positions[1]);
            Console.WriteLine(string.Join(Environment.NewLine, collection));
        }
        public static List<T> Swap<T>(List<T> collection, int p1, int p2)
        {
            T temp = collection[p1];
            collection[p1] = collection[p2];
            collection[p2] = temp;
            return collection;
        }
    }
}
