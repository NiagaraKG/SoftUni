using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphExercise
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();
            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = line[c];
                }
            }
            int count = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!visited[r, c])
                    {
                        var node = graph[r, c];
                        DFS(r, c, node);
                        count++;
                        if (areas.ContainsKey(node)) { areas[node]++; }
                        else { areas[node] = 1; }
                    }
                }
            }
            Console.WriteLine($"Areas: {count}");
            foreach (var a in areas)
            {
                Console.WriteLine($"Letter '{a.Key}' -> {a.Value}");
            }
        }

        private static void DFS(int row, int col, char node)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1)) { return; }
            if (visited[row, col]) { return; }
            if (graph[row, col] != node) { return; }
            visited[row, col] = true;
            DFS(row, col - 1, node);
            DFS(row, col + 1, node);
            DFS(row - 1, col, node);
            DFS(row + 1, col, node);
        }
    }
}