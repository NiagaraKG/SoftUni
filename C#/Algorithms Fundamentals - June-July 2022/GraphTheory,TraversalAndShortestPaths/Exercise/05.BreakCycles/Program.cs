using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExercise
{
    public class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }
        public override string ToString() { return $"{First} - {Second}"; }
    }
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ");
                var node = line[0];
                var childern = line[1].Split().ToList();
                graph[node] = childern;
                foreach (var child in childern)
                {
                    edges.Add(new Edge { First = node, Second = child });
                }
            }
            edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList();
            var removed = new List<Edge>();
            foreach (var edge in edges)
            {
                var isRemoved = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);
                if (!isRemoved) { continue; }
                if (BFS(edge.First, edge.Second))
                {
                    removed.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }
            Console.WriteLine($"Edges to remove: {removed.Count}");
            foreach (var e in removed)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static bool BFS(string start, string end)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var visited = new HashSet<string> { start };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == end)
                {
                    return true;
                }
                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            return false;
        }
    }
}