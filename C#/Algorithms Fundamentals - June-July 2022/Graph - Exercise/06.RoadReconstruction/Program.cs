using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExercise
{
    public class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public override string ToString()
        {
            if (First < Second) { return $"{First} {Second}"; }
            return $"{Second} {First}";
        }
    }
    public class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            edges = new List<Edge>();
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }
            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();
                var first = line[0];
                var second = line[1];
                graph[first].Add(second);
                graph[second].Add(first);
                edges.Add(new Edge { First = first, Second = second });
            }
            Console.WriteLine("Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);
                visited = new bool[n];
                DFS(0);
                if (visited.Contains(false))
                {
                    Console.WriteLine(edge);
                }
                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node]) { return; }
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}