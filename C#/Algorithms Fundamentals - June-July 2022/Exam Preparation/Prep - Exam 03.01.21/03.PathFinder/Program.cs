using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_01_21
{
    public class Program
    {
        private static List<int>[] graph;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    graph[node] = line.Split().Select(int.Parse).ToList();
                }
            }
            int p = int.Parse(Console.ReadLine());
            for (int i = 0; i < p; i++)
            {
                Queue<int> path = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
                Track(path);
            }
        }

        private static void Track(Queue<int> path)
        {
            while (path.Count > 1)
            {
                int first = path.Dequeue();
                int second = path.Peek();
                if (!graph[first].Contains(second))
                {
                    Console.WriteLine("no");
                    return;
                }
            }
            Console.WriteLine("yes");
        }
    }
}
