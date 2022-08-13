using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExercise
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        public static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                var parts = line.Split('-');
                if(!graph.ContainsKey(parts[0])) 
                {
                    graph.Add(parts[0], new List<string>());
                }
                graph[parts[0]].Add(parts[1]);
                if (!graph.ContainsKey(parts[1]))
                {
                    graph.Add(parts[1], new List<string>());
                }
                line = Console.ReadLine();
            }
            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }            
        }

        private static void DFS(string node)
        {
            if(cycles.Contains(node)) { throw new InvalidOperationException(); }
            if(visited.Contains(node)) { return; }
            visited.Add(node);
            cycles.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            cycles.Remove(node);
        }
    }
}