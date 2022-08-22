using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_01_21
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
                if (string.IsNullOrEmpty(line)) { graph[node] = new List<int>(); }
                else { graph[node] = line.Split().Select(int.Parse).ToList(); }
            }
            for (int i = 0; i < n - 1; i++)
            {
                bool[] areVisited = new bool[graph.Length];
                List<int> path = new List<int>();
                path.Add(i);
                FindPaths(i, n - 1, areVisited, path);
            }
        }

        private static void FindPaths(int start, int end, bool[] areVisited, List<int> path)
        {

            if (start.Equals(end)) { Console.WriteLine(string.Join(" ", path)); return; }
            areVisited[start] = true;
            foreach (int i in graph[start])
            {
                if (!areVisited[i])
                {
                    path.Add(i);
                    FindPaths(i, end, areVisited, path);
                    path.Remove(i);
                }
            }
            areVisited[start] = false;
        }
    }
}
