using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] used;
        private static int[] visited;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            graph = new List<int>[n + 1];
            used = new bool[n + 1];
            visited = new int[n + 1];
            Array.Fill(visited, -1);
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            BFS(start, end);
        }

        private static void BFS(int start, int end)
        {            
            var q = new Queue<int>();
            q.Enqueue(start);
            used[start] = true;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if(current == end)
                {
                    var path = GetPath(end);
                    Console.WriteLine($"Shortest path length is: {path.Count-1}");
                    Console.WriteLine($"{string.Join(" ", path)}");
                    break;
                }
                foreach (var child in graph[current])
                {
                    if (!used[child])
                    {
                        visited[child] = current;
                        used[child] = true;
                        q.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int end)
        {
            var path = new Stack<int>();
            var i = end;
            while (i != -1)
            {
                path.Push(i);
                i = visited[i];
            }
            return path;
        }
    }
}