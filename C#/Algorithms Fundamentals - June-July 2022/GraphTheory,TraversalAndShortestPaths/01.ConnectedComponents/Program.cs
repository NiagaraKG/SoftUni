using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];
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
            for (int node = 0; node < graph.Length; node++)
            {
                var component = new List<int>();
                DFS(node, component);
                if (component.Count > 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(" ", component)}");
                }
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node]) { return; }
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child, component);
            }
            component.Add(node);
        }
    }
}