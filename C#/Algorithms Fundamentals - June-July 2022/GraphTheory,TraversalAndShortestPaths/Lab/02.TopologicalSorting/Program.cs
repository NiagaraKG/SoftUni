using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory
{
    /*DFS algorithm
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Stack<string> sorted;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            sorted = new Stack<string>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();            
            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (Exception e)
                {                    
                    Console.WriteLine(e.Message);
                    return;
                }                
            }            
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static void DFS(string node)
        {
            if(cycles.Contains(node)) 
            {
                throw new InvalidOperationException("Invalid topological sorting");

            }
            if (visited.Contains(node)) { return; }
            cycles.Add(node);
            visited.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            sorted.Push(node);
            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
                var key = parts[0];
                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    result[key] = parts[1].Split(", ").ToList();
                }
            }
            return result;
        }*/


    // BFS algorithm

    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            dependencies = ExtractDependencies(graph);
            var sorted = new List<string>();
            while (dependencies.Count > 0)
            {
                var toBeRemoved = dependencies.FirstOrDefault(d => d.Value == 0).Key;
                if (toBeRemoved == null) { break; }
                dependencies.Remove(toBeRemoved);
                sorted.Add(toBeRemoved);
                foreach (var c in graph[toBeRemoved])
                {
                    dependencies[c]--;
                }
            }
            if (dependencies.Count == 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");

            }
            else { Console.WriteLine("Invalid topological sorting"); }
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> currentGraph)
        {
            var result = new Dictionary<string, int>();
            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;
                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }
                foreach (var c in children)
                {
                    if (!result.ContainsKey(c))
                    {
                        result[c] = 1;
                    }
                    else
                    {
                        result[c]++;
                    }
                }
            }
            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
                var key = parts[0];
                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    result[key] = parts[1].Split(", ").ToList();
                }
            }
            return result;
        }
    }
}