using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        public static void Main()
        {
            ReadGraph();
            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
            Console.WriteLine(String.Join(" ", visited.Reverse()));
        }

        private static void ReadGraph()
        {
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] elements = line.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                var preStory = elements[0];
                if (!graph.ContainsKey(preStory))
                {
                    graph[preStory] = new List<string>();
                }
                if (elements.Length < 2) { continue; }
                string[] postStories = elements[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                graph[preStory].AddRange(postStories);
            }
        }

        private static void DFS(string parent)
        {
            if (visited.Contains(parent)) { return; }
            foreach (var child in graph[parent]) { DFS(child); }
            visited.Add(parent);
        }
    }
}