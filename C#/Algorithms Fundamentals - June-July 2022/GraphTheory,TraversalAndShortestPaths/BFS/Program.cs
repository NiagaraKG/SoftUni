using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        public static void Main()
        {
            graph = new Dictionary<int, List<int>>
            {
                {1, new List<int> {19,21,14}},
                {19, new List<int> {7, 12, 31, 21}},
                {7, new List<int> {1}},
                {31, new List<int> {21}},
                {21, new List<int> {14}},
                {23, new List<int> {21}},
                {14, new List<int> {23, 6}},
                {12, new List<int> ()},
                {6, new List<int> ()},
            };
            visited = new HashSet<int>();
            foreach (var node in graph.Keys)
            {
                BFS(node);
            }
        }

        private static void BFS(int node)
        {
            if (visited.Contains(node)) { return; }
            var q = new Queue<int>();
            q.Enqueue(node);
            visited.Add(node);
            while(q.Count > 0)
            {
                var current = q.Dequeue();
                Console.WriteLine(current);
                foreach (var child in graph[current])
                {
                    if(!visited.Contains(child))
                    {
                        visited.Add(child);
                        q.Enqueue(child);
                    }
                }
            }
        }
    }
}