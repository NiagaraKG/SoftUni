using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExercise
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        public static void Main()
        {
            int vertices = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < vertices; i++)
            {
                var line = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(line[0]);
                if (line.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line[1].Split().Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }
            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
                var steps = BFS(pair[0], pair[1]);
                Console.WriteLine($"{{{pair[0]}, {pair[1]}}} -> {steps}");
            }
        }

        private static int BFS(int start, int end)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
            var visited = new HashSet<int> { start };
            var parent = new Dictionary<int, int> { { start, -1 } };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == end)
                {
                    return GetSteps(parent, end);
                }
                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                        parent[child] = node;
                    }
                }
            }
            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int end)
        {
            var steps = 0;
            var node = end;
            while (node != -1)
            {
                node = parent[node];
                steps++;
            }
            return steps - 1;
        }
    }
}