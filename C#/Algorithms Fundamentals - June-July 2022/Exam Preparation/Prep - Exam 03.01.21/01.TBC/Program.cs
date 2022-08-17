using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_01_21
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        public static int size;
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            graph = new char[rows, cols];
            visited = new bool[rows, cols];
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
                        size = 0;
                        if(DFS(r, c) > 0)
                        count++;                        
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static int DFS(int row, int col)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1)) { return 0; }
            if (visited[row, col]) { return 0; }
            if (graph[row, col] != 't') { return 0; }
            visited[row, col] = true;
            size++;
            size += DFS(row, col - 1);
            size += DFS(row, col + 1);
            size += DFS(row - 1, col);
            size += DFS(row + 1, col);
            size += DFS(row -1, col-1);
            size += DFS(row -1, col+1);
            size += DFS(row +1, col+1);
            size += DFS(row +1, col-1);
            return size;
        }
    }
}
